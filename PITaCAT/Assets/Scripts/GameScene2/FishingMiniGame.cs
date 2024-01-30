using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingMiniGame : MonoBehaviour
{
    public GameObject REButton;

   
    
    public GameObject[] fishes;      //드랍할 물고기 배열
    public GameObject restartbutton;
    public GameObject endtbutton;

    //범위
    [SerializeField] Transform topPriviot;
    [SerializeField] Transform buttomPriviot;

    //물고기 위치(미니게임)
    [SerializeField] Transform fish;

    float fishPosition;
    float fishDestination;

    float fishTimer;
    [SerializeField] float timerMultipleicator = 3f;

    float fishSpeed;
    [SerializeField] float sommthMotion = 1f;

    [SerializeField] Transform hook;
    float hookPosition;
    [SerializeField] float hooksize = 0.08f;
    [SerializeField] float hookPower = 5f;
    float hookProgress;
    float hookPullVelocity;
    [SerializeField] float hookPullPower = 0.01f;
    [SerializeField] float hookGravityPower = 0.005f;
    [SerializeField] float hookProgressDegradationPower = 0.1f;

    [SerializeField] SpriteRenderer hookSpriteRenderer;

    [SerializeField] Transform progressBarController;

    public bool pause=true;
    fishdrop sc;
    [SerializeField] float failTimer = 10f;

    public void Start() 
    {
        Resize();
        sc = GameObject.Find("Player").GetComponent<fishdrop>();
    }
   
    public void Update()
    {
       GStart();
    }

    public void Resize()
    {
        Bounds b = hookSpriteRenderer.bounds;
        float ySize = b.size.y;
        Vector3 ls = hook.localScale;
        float distance = Vector3.Distance(buttomPriviot.position, topPriviot.position);
        ls.y = (distance / ySize * hooksize);
        hook.localScale = ls;
    }

    public void ProgressCheck()
    {
        Vector3 ls = progressBarController.localScale;
        ls.y = hookProgress;
        progressBarController.localScale = ls;

        float min = hookPosition - hooksize / 2;
        float max=hookPosition + hooksize / 2;

        if (min < fishPosition && fishPosition < max) {
            hookProgress += hookPower * Time.deltaTime;
        }
        else
        {
            hookProgress -= hookProgressDegradationPower * Time.deltaTime;

            failTimer -= Time.deltaTime;
            if (failTimer < 0f) {
                Lose();
            }
        }

        if (hookProgress >= 1f){
            Win();
        }

        hookProgress = Mathf.Clamp(hookProgress, 0f, 1f);
    }
    public void Lose()
    {
        pause = true;
        Debug.Log("You LOSE! FISH SWIM AWAY FROM YOU!");
        REButton.SetActive(true);
        restartbutton.SetActive(true);
        endtbutton.SetActive(true);

    }
    public void Win()
    {
        pause = true;
        Debug.Log("You Win! YOU CAUGTH THE FISH!");
        REButton.SetActive(true);
        restartbutton.SetActive(true);
        endtbutton.SetActive(true);
        //아이템 드롭 함수 추가하기
        sc.trans.position=sc.trans.transform.position;
        sc.fishDrop();
    }

    public void Hook() 
    {
        if (Input.GetMouseButton(0)) 
        {
            hookPullVelocity += hookPullPower * Time.deltaTime;
        }
        hookPullVelocity -= hookGravityPower * Time.deltaTime;

        hookPosition += hookPullVelocity;

        if(hookPosition-hooksize/2 < 0f&&hookPullVelocity<0f) 
        {
            hookPullVelocity = 0f;
        }
        if(hookPosition + hooksize / 2 >= 1f && hookPullVelocity > 0f) 
        {
            hookPullVelocity = 0f;
        }

        hookPosition = Mathf.Clamp(hookPosition, hooksize/2, 1-hooksize/2);
        hook.position= Vector3.Lerp(buttomPriviot.position, topPriviot.position, hookPosition);
    }

    public  void Fish() 
    {
        fishTimer -= Time.deltaTime;
        if (fishTimer < 0f)
        {
            fishTimer = UnityEngine.Random.value * timerMultipleicator;

            fishDestination = UnityEngine.Random.value;
        }

        fishPosition = Mathf.SmoothDamp(fishPosition, fishDestination, ref fishSpeed, sommthMotion);
        fish.position = Vector3.Lerp(buttomPriviot.position, topPriviot.position, fishPosition);
    }

    public void GStart() {
        
        if (pause) { return; }
        Fish();
        Hook();
        ProgressCheck();
    }

    public void Restart() {
        pause = false;
        hookPosition = 0;
        fishPosition = 0;
        hookProgress = 0;
        failTimer = 10;

        GStart();
        
        // Debug.Log("재실행");
    }
}