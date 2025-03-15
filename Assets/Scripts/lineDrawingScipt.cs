using UnityEngine;
using System.Collections.Generic;
using System.Linq; 

public class lineDrawingScipt : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider;
    private List<Vector2> points;
    Vector2 offset = new Vector2(0, -0.1f);

    public PhysicsMaterial2D bounceMaterial;
    void Start()
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

    }

    void Update()
    {
        drawLine();
    }

    private void drawLine()
    {
        if (Input.GetMouseButtonDown(0))
        {
            points.Clear();
            lineRenderer.positionCount = 0;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;

            if (points.Count == 0 || Vector2.Distance(points[points.Count - 1], mousePos) > 0.1f)
            {
                points.Add(mousePos);
                lineRenderer.positionCount = points.Count;
                lineRenderer.SetPosition(points.Count - 1, mousePos);
                Vector2 offset = new Vector2(0, 0.5f);
                Vector2[] adjustedPoints = points.Select(p => (Vector2)p + offset).ToArray();
                edgeCollider.points = adjustedPoints;
            }
        }
    }
}
