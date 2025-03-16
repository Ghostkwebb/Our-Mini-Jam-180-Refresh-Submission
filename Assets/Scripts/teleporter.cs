using UnityEngine;

public class teleporter : MonoBehaviour
{
    [SerializeField] private Transform destination;
    GameObject ball;

    private void Awake()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ball"))
        {
            if (Vector2.Distance(ball.transform.position, transform.position) > 0.6f)
            {
                ball.transform.position = destination.transform.position;
            }
        }
    }
}

