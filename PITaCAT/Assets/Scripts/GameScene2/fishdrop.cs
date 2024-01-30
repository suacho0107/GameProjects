using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class fishdrop : MonoBehaviour
{
    Rigidbody rb;
    FishingMiniGame sc2;  //FishingMiniGame스크립트 가져오기 위해 사용
    public  Image[] fise2;   //물고기의 색상 변경을 위한 배열->이미지 넣기(fishboard속 5개 프리팹 ex)1-1)
    public GameObject[] fishes;  //물고기를 랜덤으로 화면에 드랍하기위한 배열->물고기 프리팹 5개 넣기
    public Transform trans;
    int [] fishscore  = new int[] { 0,0,0,0,0 }; //클리어조건
    public bool fclear=false;

    // 종료 조건
    public GameObject clearPanel2;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
       sc2= GameObject.Find("fishingMiniGame").GetComponent<FishingMiniGame>();  //FishingMiniGame스크립트 가져오기 위해 사용
    }

    //랜덤값 설정-스태틱으로 설정해서 다른 함수에서도 같은 값이 들어가도록 함.
    public static int randdrop() {
        int rand = Random.Range(0, 5);
        return rand;
    }
    static int ad;

    //물고기 드랍
    public void  fishDrop()
    {
        ad=randdrop();
        float rand2 = Random.Range(1, 1.5f);
        Vector3 v = new Vector3(0f, rand2, rand2);
        Instantiate(fishes[ad], trans.position + v, Quaternion.identity);
        
    }
    //물고기UI 색상 변경
    public void changefishcolor(int a)
    {

        fise2[a].color = new Color(255, 255, 255);

    }
    //물고기를 먹을때
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "fish")
        {
            //물고기 색상 바꾸기
            changefishcolor(ad);
            Destroy(col.gameObject);
            fishscore[ad] = 1;
            Debug.Log(ad+"물고기 추가");

            isclearfishgame();
            if(isclearfishgame()==true)
            {
                // 이곳이야 !_SetActive(종료 패널 on, 버튼 클릭 후 클리어씬 이동)
                // Debug.Log("clear");
                clearPanel2.SetActive(true);
            }
        }
        
    }//낚시 미니게임 클리어 조건 확인문
    bool  isclearfishgame()
    {
        int cou=0;
        for (int i = 0; i < fishscore.Length; i++) 
        {
            if (fishscore[i] >= 1)
                cou++;
        }
        if (cou == 5)
            fclear = true;
        else
            fclear = false;

        return fclear;
    }
}
