using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCharacter : MonoBehaviour {
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    public CoinManager cm;

    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public Transform GroundCheck;
    [SerializeField] public LayerMask groundLayer;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButton("Jump") && IsGrounded()) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButton("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 1.0f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded() 
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f  || !isFacingRight && horizontal > 0f) 
        { 
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;

        }
            
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin")) 
        {
            Destroy(other.gameObject);
            cm.coinCount++;
        }
    }

}

