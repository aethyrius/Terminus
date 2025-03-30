using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 5f;
    private float direction;
    private float jumpForce = 6;
    private bool grounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        bool isTerminalClosed = gameObject.GetComponent<TerminalManager>().isTerminalClosed;

        if (isTerminalClosed)
        {
            direction = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(direction * speed, rb.velocity.y);

            if (Input.GetKeyDown(KeyCode.Space) && grounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
        else
        {
            float smoothedX = Mathf.Lerp(rb.velocity.x, 0f, Time.deltaTime * 4);
            rb.velocity = new Vector2(smoothedX, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}
