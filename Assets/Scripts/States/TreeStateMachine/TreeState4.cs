using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeState4 : State
{
    public static TreeState4 INSTANCE;
    bool once;

    //Intro
    public GameObject cameraPoint;
    public cameraFollow cameraFoll;
    public GameObject player;
    public bool cameraZoomOut;
    public float cameraZoomScale;
    public float brokenShieldTimer;

    public void Awake()
    {
        if (INSTANCE != null) Destroy(this.gameObject);
        INSTANCE = this;
        DontDestroyOnLoad(this.gameObject);
    }
    public void Update()
    {
        brokenShieldTimer += Time.deltaTime;
        cameraFoll.player = GameObject.FindGameObjectWithTag("CameraPoint").transform;

        if (cameraZoomScale > 11f)
        {
            cameraZoomScale -= 2 * Time.deltaTime;
            cameraFoll.cameraDistance = cameraZoomScale;
            if (cameraZoomScale < 17)
            {
                cameraPoint.transform.position = Vector3.MoveTowards(cameraPoint.transform.position, player.transform.position, 5 * Time.deltaTime);
            }
        }
        else
            cameraFoll.player = player.transform;

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
}