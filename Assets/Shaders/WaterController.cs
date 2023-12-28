using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public float maxLenght;
    public float fallSpeed;
    public BoxCollider2D boxCollider2D;
    public LineRenderer lineRenderer;
    public LayerMask obstacleLayerMask;
    public GameObject splashEffectObject;
    public SpriteMask spriteMask;

    private float lastLength;
    private int postProcessingLayer;

    private void Start()
    {
        lineRenderer.positionCount = 2;
        for (int i = 0; i < 2; i++)
        {
            lineRenderer.SetPosition(i, transform.position);
        }
        if (spriteMask != null)
        {
            lineRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        }

        postProcessingLayer = LayerMask.NameToLayer("PostProcessing");
    }

    private void Update()
    {
        GetCurrentLength(out float currentMaxLength);
        CalculateActualLength(currentMaxLength, out float currentLength);
        ResizeLine(currentLength);
        RescaleCollider(currentLength);
        CheckForSplashEffect(currentLength, currentMaxLength);
    }

    public void GetCurrentLength(out float currentMaxLength)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, maxLenght, obstacleLayerMask);
        if (hit)
            currentMaxLength = Vector3.Distance(transform.position, hit.point);
        else
            currentMaxLength = maxLenght;
    }
    public bool HasReachedFullLength()
    {
        GetCurrentLength(out float currentMaxLength);
        return Mathf.Approximately(lastLength, currentMaxLength);
    }
    public void CalculateActualLength(float currentMaxLength, out float currentLength)
    {
        currentLength = lastLength + Time.deltaTime * fallSpeed;
        currentLength = Mathf.Clamp(currentLength, 0, currentMaxLength);
        lastLength = currentLength;
    }

    public void ResizeLine(float currentLength)
    {
        lineRenderer.SetPosition(1, transform.position - Vector3.up * currentLength);
        lineRenderer.material.SetFloat("_Length", currentLength);
    }

    public void RescaleCollider(float currentLength)
    {
        boxCollider2D.size = new Vector2(boxCollider2D.size.x, currentLength);
        boxCollider2D.offset = new Vector2(0, -currentLength / 2);
    }

    public void CheckForSplashEffect(float currentLength, float currentMaxLength)
    {
        if (currentLength >= currentMaxLength && IsWithinMaskBounds())
        {
            splashEffectObject.SetActive(true);
            splashEffectObject.layer = postProcessingLayer;
            splashEffectObject.transform.position = transform.position - Vector3.up * currentLength;
        }
        else
        {
            splashEffectObject.SetActive(false);
        }
    }

    private bool IsWithinMaskBounds()
    {
        if (spriteMask == null) return false;

        Bounds maskBounds = new Bounds(spriteMask.transform.position, spriteMask.bounds.size);
        Vector3 endPosition = transform.position - Vector3.up * lastLength;

        return maskBounds.Contains(endPosition);
    }
}