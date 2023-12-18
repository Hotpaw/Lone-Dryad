using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectRotation : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
        transform.DORotate(new Vector3(0,0,360),5,RotateMode.FastBeyond360).SetLoops(-1);
    }
}
