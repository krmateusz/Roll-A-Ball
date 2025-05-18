using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class MovementController : MonoBehaviour
{

    private Rigidbody rb;
    public AudioSource audiosource;
    public float speed = 7f;
    public float score = 0f;
    private float jumpForce = 150f;
    private bool isGrounded, left, right, up, down, jumped;
    public Transform orientation;
    public bool useFirstPersonMovement = false;
    public event Action pickupEvent;
    public event Action levelChange;

    void Start()
    {
        audiosource = GameObject.Find("jump").GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CheckInputs();
    }

    void FixedUpdate()
    {
        if (useFirstPersonMovement)
        {
            CheckFirstPersonMovement();
        }
        else
        {
            CheckMovement();
        }
    }

    public void CollectScore()
    {
        score++;
        pickupEvent?.Invoke();
        levelChange?.Invoke();
    }

    private void CheckInputs()
    {

        if (!up && Input.GetKey(KeyCode.W))
        {
            up = true;
        }
        if (!down && Input.GetKey(KeyCode.S))
        {
            down = true;
        }
        if (!left && Input.GetKey(KeyCode.A))
        {
            left = true;
        }
        if (!right && Input.GetKey(KeyCode.D))
        {
            right = true;
        }
        if (!jumped && Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumped = true;
            audiosource.Play();
        }
    }

    private void CheckMovement()
    {
        if (left)
        {
            left = false;
            rb.AddForce(-1 * speed, 0, 0);
        }
        if (right)
        {
            right = false;
            rb.AddForce(1 * speed, 0, 0);
        }
        if (up)
        {
            up = false;
            rb.AddForce(0, 0, 1 * speed);
        }
        if (down)
        {
            down = false;
            rb.AddForce(0, 0, -1 * speed);
        }
        if (jumped)
        {
            jumped = false;
            rb.AddForce(0, jumpForce, 0);

        }

    }
    private void CheckFirstPersonMovement()
    {

        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += orientation.forward; 
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection -= orientation.forward; 
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection -= orientation.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += orientation.right; 
        }

        moveDirection = moveDirection.normalized;
        rb.AddForce(moveDirection * speed, ForceMode.Force);
        if (jumped)
        {
            jumped = false;
            rb.AddForce(Vector3.up * jumpForce * 0.02f, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
