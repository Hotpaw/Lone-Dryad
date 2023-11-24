using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WaterController : MonoBehaviour
{
    public float maxLenght;
    public float fallSpeed;
    public BoxCollider2D boxCollider2D;
    public LineRenderer lineRenderer;
    public LayerMask obstacleLayerMask;
   public GameObject splashEffectObject;

    private float lastLength;

    private void Start()
    {
        lineRenderer.positionCount = 2;
        for (int i = 0; i < 2; i++)
        {
            lineRenderer.SetPosition(i,transform.position);
        }
    }
    private void Update()
    {
        GetCurrentLength(out float currenMaxLength);
        CalculateActualLength(currenMaxLength, out float currenLength);
        ResizeLine(currenLength);
        RescaleCollider(currenLength);
        CheckForSplashEffect(currenLength, currenMaxLength);
    }
    public void GetCurrentLength(out float currentMaxLength)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, maxLenght, obstacleLayerMask);
        if (hit)
            currentMaxLength = Vector3.Distance(transform.position, hit.point);
        else
            currentMaxLength = maxLenght;
    }
    public void CalculateActualLength(float currentMaxLength,out float currentLength)
    {
        currentLength = lastLength + Time.deltaTime * fallSpeed;
        currentLength = Mathf.Clamp(currentLength, 0, currentMaxLength);
        lastLength = currentLength;
    }
    public void ResizeLine(float currentLength)
    {
        lineRenderer.SetPosition(1,transform.position - Vector3.up * currentLength);
        lineRenderer.material.SetFloat("_Length", currentLength);
    }
    public void RescaleCollider(float currentLength)
    {
        boxCollider2D.size = new Vector2(boxCollider2D.size.x, currentLength);
        boxCollider2D.offset = new Vector2(0, -currentLength / 2);
    }
    public void CheckForSplashEffect(float currentLength, float currentMaxLength)
    {
        splashEffectObject.SetActive(currentLength >= currentMaxLength);
        splashEffectObject.transform.position = transform.position - Vector3.up * currentLength;
    }
}
