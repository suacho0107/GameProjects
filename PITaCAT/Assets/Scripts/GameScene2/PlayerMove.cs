using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    float h;
    float v;
    bool isHorizonMove;
    Rigidbody2D rigid;
    public float Speed;
    Animator anim;
    Vector3 dirVec;
    GameObject scanObject;
    GameObject fisingmode;
    public GameObject fishrod;
    public GameObject rod_st;
    public GameObject rod_e;
    public GameObject fishingMinigame;
    public GameObject Explain;
    public Button FishigStart;
    public FishingMiniGame restart2;


    void Start()
    {
        restart2 = GameObject.Find("fishingMiniGame").GetComponent<FishingMiniGame>();
    }
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        if (hDown)
            isHorizonMove = true;
        else if (vDown)
            isHorizonMove = false;
        else if (hUp || vUp)
            isHorizonMove = h != 0;

        if (anim.GetInteger("HAxisRaw") != h)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("HAxisRaw", (int)h);
        }
        else if (anim.GetInteger("VAxisRaw") != v)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("VAxisRaw", (int)v);
        }
        else {
            anim.SetBool("isChange", false);
        }

        //Direction
        if (vDown && v == 1)
            dirVec = Vector3.up;
        if (vDown && v == -1)
            dirVec = Vector3.down;
        if (hDown && h == -1)
            dirVec = Vector3.left;
        if (hDown && h == 1)
            dirVec = Vector3.right;

        //scan Oblect
        if (Input.GetKeyDown(KeyCode.Space) && scanObject != null) 
        {
            Debug.Log("This is " + scanObject.name);
        }
            
        //³¬½Ã¸ðµå
        if (Input.GetKeyDown(KeyCode.R) && fisingmode != null) {

            if (fishrod.activeSelf == true)
            {
                 //fisingmode.SetActive(false);
                restart2.pause = true;
                Debug.Log("Natural mode1");
                fishrod.SetActive(false);
                if(Explain==true) { Explain.SetActive(false); }

                fishingMinigame.SetActive(false);
            }

            else if (rod_e.activeSelf == true)
            {
                restart2.pause = true;
                //fisingmode.SetActive(false);
                Debug.Log("Natural mode2");
                rod_e.SetActive(false);

                fishingMinigame.SetActive(false);
            }

            else if (fishrod.activeSelf == false || rod_e.activeSelf == false)
            {
                //fisingmode.SetActive(true);
                Debug.Log("fishing mode");
                fishrod.SetActive(true);
                //fishingMinigame.SetActive(true);
                Explain.SetActive(true);
                
                //restart2.GStart();
            }
        }
    }

    void FixedUpdate() {
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * Speed;

        //Ray
        Debug.DrawRay(rigid.position, dirVec*0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 1.5f, LayerMask.GetMask("sea"));
        RaycastHit2D rayHit2 = Physics2D.Raycast(rigid.position, dirVec, 1.5f, LayerMask.GetMask("object"));

        if (rayHit2.collider != null) {
            scanObject = rayHit2.collider.gameObject;
        }
        else
            scanObject = null;
        if (rayHit.collider != null)
        {
            fisingmode = rayHit.collider.gameObject;
        }
        else
            fisingmode = null;

    }
}
