using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [Range(0.5f, 20f)]
    [SerializeField]
    private float speed = 5f;

    [Range(0.5f, 30f)]
    [SerializeField]
    private float horizontalSpeed = 15f;

    [SerializeField]
    private Rigidbody rb;

    [Header("Score")]
    [SerializeField]
    private int score;

    [SerializeField]
    private TMP_Text scoreText;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return;
        }

        if (other.CompareTag("Coin"))
        {
            score++;

            scoreText.text = score.ToString("00000");
        }
    }
}
