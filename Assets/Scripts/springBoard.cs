using UnityEngine;
using System.Collections;

public class springBoard : MonoBehaviour
{
    [Header("Spring Board Settings")]
    [Header("Rotation Settings")]
    [SerializeField] private float rotateAngle = 30f;
    [SerializeField] private float rotationSpeed = 5f;
    [Header("Launch Settings")]
    [SerializeField] private float launchForce = 10f;

    private bool isRotating = false;
    private float currentRotation = 0f;
    private float targetRotation;
    private Rigidbody2D ballRb;
    private float initialZRotation;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball") && !isRotating)
        {
            isRotating = true;
            ballRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (ballRb != null)
            {
                Vector2 launchDirection = transform.up;
                ballRb.AddForce(launchDirection * launchForce, ForceMode2D.Impulse);
                initialZRotation = transform.localEulerAngles.z;
                targetRotation = initialZRotation + rotateAngle;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isRotating)
        {
            float step = rotationSpeed * Time.fixedDeltaTime;
            currentRotation = Mathf.MoveTowards(transform.localEulerAngles.z, targetRotation, step);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, currentRotation);

            if (Mathf.Abs(currentRotation - targetRotation) < 0.1f)
            {
                isRotating = false;
            }
        }
    }
}
