using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public CharacterController player;
    public float jumpForce;
    public float fallVelocity;
    public float gravity;
    private Vector3 movePlayer;

    private Rigidbody rb; public int rapidez;
    void Start()
    {
        player = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 vectorMovimiento = new Vector3(movimientoHorizontal, 0.0f, movimientoVertical);

        transform.position = transform.position + vectorMovimiento * rapidez * Time.deltaTime;

        SetGravity();
        PlayerJump();

    }

    public void PlayerJump()
    {
        if (player.isGrounded && Input.GetButtonDown("Jump"))
        {
            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity;
        }
    }

    public void SetGravity()
    {
        if (player.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(1);
        }

        if (collision.gameObject.CompareTag("Goal"))
        {
            SceneManager.LoadScene(3);
        }

    }

}
