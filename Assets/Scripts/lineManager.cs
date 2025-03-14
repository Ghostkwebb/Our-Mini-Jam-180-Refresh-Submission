using UnityEngine;
using System.Collections.Generic;

public class LineManager : MonoBehaviour
{
    public int maxLines = 5; 
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
