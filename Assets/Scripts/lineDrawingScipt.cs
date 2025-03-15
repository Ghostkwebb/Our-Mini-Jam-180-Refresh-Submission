using UnityEngine;
using System.Collections.Generic;
using System.Linq; 

public class lineDrawingScipt : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider;
    private List<Vector2> points;
    private float currentLineLength = 0f;

    [Header("Material For line")]
    public PhysicsMaterial2D bounceMaterial;
    [Header("Max Line Length")]
    public float maxLineLength = 10f;

    void Awake()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startWidth = 0.5f;
        lineRenderer.endWidth = 0.5f;
        lineRenderer.numCapVertices = 5;

        edgeCollider = gameObject.AddComponent<EdgeCollider2D>();
        edgeCollider.edgeRadius = 0.3f;
        points = new List<Vector2>();
        
        if (bounceMaterial != null) edgeCollider.sharedMaterial = bounceMaterial;

        points = new List<Vector2>();

    }

    public void AddPoint(Vector3 worldPos)
    {
        worldPos.z = 0f;

        if (points.Count == 0 || Vector2.Distance(points[points.Count - 1], worldPos) > 0.1f)
        {
            if (points.Count > 0)
            {
                float segmentLength = Vector2.Distance(points[points.Count - 1], worldPos);
                if (currentLineLength + segmentLength > maxLineLength)
                    return;
                currentLineLength += segmentLength;
            }
            
            points.Add(worldPos);
            lineRenderer.positionCount = points.Count;
            lineRenderer.SetPosition(points.Count - 1, worldPos);

            Vector2 offset = new Vector2(0, -0.1f);
            Vector2[] adjustedPoints = points.Select(p => (Vector2)p + offset).ToArray();
            edgeCollider.points = adjustedPoints;
        }
    }
}    
