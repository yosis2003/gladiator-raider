using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private float moveH;
    private float jumpPower = 16f;
    private bool faceRight = true;


    public Rigidbody2D player;
    private Transform groundCheck;
    private LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveH = Input.GetAxisRaw("Horizontal");
        player.velocity = new Vector2(moveH * speed, player.velocity.y);
        Flip();

        if (Input.GetButtonDown("Jump") && Grounded())
        {
            player.velocity = new Vector2(player.velocity.x, jumpPower);
        }
    }
    private bool Grounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void Flip()
    {
        if (faceRight && moveH < 0f || !faceRight && moveH > 0f)
        {
            faceRight =! faceRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale; 
        }
    }

}
