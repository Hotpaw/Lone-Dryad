using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class shieldScript : MonoBehaviour
{    
    public Vector3 scaleSize;
    // Start is called before the first frame update
    void Start()
    {
        scaleSize = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.DOScale(scaleSize * 1.1f, 0.1f).SetLoops(-1, LoopType.Yoyo);
    }
}
