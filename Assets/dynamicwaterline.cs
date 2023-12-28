using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DynamicWaterLine : MonoBehaviour
{
    public float thickness = 0.5f;
    public int segmentCount = 20;
    public float length = 10.0f;

    private LineRenderer lineRenderer;
    private Vector3 previousPosition;
    private float previousLength;
    private int previousSegmentCount;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        UpdateLineRenderer();
    }

    void Update()
    {
        if (transform.position != previousPosition || length != previousLength || segmentCount != previousSegmentCount)
        {
            UpdateLineRenderer();
        }

        previousPosition = transform.position;
        previousLength = length;
        previousSegmentCount = segmentCount;
    }

    void UpdateLineRenderer()
    {
        SetupLineRenderer();
     //   PositionLineRenderer();
    }

    void SetupLineRenderer()
    {
        lineRenderer.startWidth = thickness;
        lineRenderer.endWidth = thickness;
        lineRenderer.positionCount = segmentCount;
    }

    void PositionLineRenderer()
    {
        Vector3 localStartPoint = new Vector3(-length / 2, 0, 0);
        Vector3 localEndPoint = new Vector3(length / 2, 0, 0);
        Vector3 localDelta = (localEndPoint - localStartPoint) / (segmentCount - 1);

        for (int i = 0; i < segmentCount; i++)
        {
            Vector3 pointPosition = localStartPoint + localDelta * i;
            lineRenderer.SetPosition(i, transform.TransformPoint(pointPosition));
        }
    }
}