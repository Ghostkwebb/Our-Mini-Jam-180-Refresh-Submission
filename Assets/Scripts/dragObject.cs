using UnityEngine;

public class dragObject : MonoBehaviour
{
    bool draging = false;
    Vector3 offset;

    void Update()
    {
        if(draging){
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }

    void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        draging = true;   
    }

    void OnMouseUp()
    {
       draging = false; 
    }
}
