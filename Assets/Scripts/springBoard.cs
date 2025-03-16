using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class springBoard : MonoBehaviour
{
    [SerializeField] private GameObject gameObject;
    [SerializeField] private float rotateAngle;
    [SerializeField] private Transform rb;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            transform.Rotate(0, 0, rotateAngle);
        }
    }
}
