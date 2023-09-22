using UnityEngine;

[ExecuteInEditMode]
public class PlayerController : MonoBehaviour
{
    [Range(0.5f, 20f)]
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private Rigidbody rb;

    private void FixedUpdate()
    {
        var movement = Vector3.forward * speed;
        rb.velocity = movement;
    }
}
