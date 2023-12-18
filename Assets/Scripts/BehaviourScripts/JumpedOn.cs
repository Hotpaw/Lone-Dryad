using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JumpedOn : MonoBehaviour
{
    public Vector3 originalScale;
    public Vector3 newScale;

    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;
        newScale = new Vector3 (1.2f, originalScale.y * 0.4f ,1 );
    }

    public void JumpedOnScale()
    {
        transform.DOScale(newScale, 0.3f)
                    .SetEase(Ease.InOutSine)
                    .SetLoops(2, LoopType.Yoyo); 
    }
}
