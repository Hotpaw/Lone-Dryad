using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreeState4 : State
{
    public static TreeState4 INSTANCE;

    //Intro
    public GameObject cameraPoint;
    public cameraFollow cameraFoll;
    public GameObject player;
    public blackOut blackOut;

    public Transform walkingAroundPoint;
    public Transform walkingAroundPoint2;
    public bool walkBack;
    public bool cameraZoomOut;
    public float cameraZoomScale;
    public float timer;
    public bool once;

    public void Awake()
    {
        if (INSTANCE != null) Destroy(this.gameObject);
        INSTANCE = this;
        DontDestroyOnLoad(this.gameObject);
    }
    public void Update()
    {
        timer += Time.deltaTime;
        cameraFoll.player = GameObject.FindGameObjectWithTag("CameraPoint").transform;
        cameraFoll.cameraDistance = 25;
        if(timer > 3)
        {

            if (!walkBack)
            {
                player.transform.position = Vector3.MoveTowards(player.transform.position, walkingAroundPoint.position, 3 * Time.deltaTime);
                player.GetComponent<Animator>().SetFloat("Speed", 0.2f);
            }
            else if (walkBack)
            {
                player.transform.position = Vector3.MoveTowards(player.transform.position, walkingAroundPoint2.position, 3 * Time.deltaTime);
                player.GetComponent<Animator>().SetFloat("Speed", 0.2f);
                player.GetComponent<SpriteRenderer>().flipX = true;
            }
            if (Vector2.Distance(player.transform.position, walkingAroundPoint.position) < 1)
            {
                player.GetComponent<Animator>().SetFloat("Speed", 0f);
                player.GetComponent<Animator>().SetTrigger("PickingUP");
                StartCoroutine(YieldTurnAround());
            }
        }
        if (timer > 7 && !once)
        {
            blackOut.fadeSpeed = 0.5f;
            blackOut.startBlackOut = true;
            StartCoroutine(YieldNextStage());
            once = true;
        }      
    }
    public override State RunCurrentState()
    {
        if (GameValueManager.INSTANCE.treeLevel == 4)
        {
            return this;
        }
        else
        {
            return TreeState5.INSTANCE;
        }
    }
    public IEnumerator YieldTurnAround()
    {
        yield return new WaitForSeconds(1f);
        walkBack = true;
    }
    public IEnumerator YieldNextStage()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(5);

    }
}