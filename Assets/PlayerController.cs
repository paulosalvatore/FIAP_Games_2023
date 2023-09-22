using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0.5f, 20f)]
    [SerializeField]
    private float speed = 5f;

    [Range(0.5f, 30f)]
    [SerializeField]
    private float horizontalSpeed = 15f;

    [SerializeField]
    private Rigidbody rb;

    private void Update()
    {
        var h = Input.GetAxis("Horizontal");
        rb.MovePosition(rb.position + Vector3.right * (h * horizontalSpeed * Time.deltaTime));
    }

    private void FixedUpdate()
    {
        var movement = Vector3.forward * speed;
        movement.y = rb.velocity.y;
        rb.velocity = movement;
    }
}
