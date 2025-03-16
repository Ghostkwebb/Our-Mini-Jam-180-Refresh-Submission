using UnityEngine;
using System.Collections.Generic;

public class LineManager : MonoBehaviour
{
    [Header("Max Lines")]
    public int maxLines = 5; 
    [Header("Material For line")]
    public PhysicsMaterial2D lineBounceMaterial;
    [Header("Max Line Length")]
    public float maxLineLength = 10f;


    private List<GameObject> drawnLines = new List<GameObject>();
    private lineDrawingScipt activeLine = null;

    void Update()
    {
        lineController();
    }

    private void lineController()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (activeLine == null && drawnLines.Count < maxLines)
            {
                GameObject newLineGO = new GameObject("Line");
                activeLine = newLineGO.AddComponent<lineDrawingScipt>();
                activeLine.SetBounceMaterial(lineBounceMaterial);
                activeLine.maxLineLength = maxLineLength;
                drawnLines.Add(newLineGO);
            }
        }

        if (Input.GetMouseButton(0) && activeLine != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.AddPoint(mousePos);
        }

        if (Input.GetMouseButtonUp(0))
        {
            activeLine = null;
        }
    }
}
