using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float slowerFactor = 0.5f;
    private bool faceRight = true;
    private float moveH;

    [SerializeField] public Rigidbody2D enemy;
    [SerializeField] public Rigidbody2D player;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private void Update()
    {
        mover();
        Flip();
    }
    private void mover()
    {
        Vector3 playerVel = player.velocity;
        float playerX = playerVel.x;
        if (player.position.x < enemy.position.x)
        {
            
            enemy.velocity = new Vector3 (playerX * slowerFactor * -1.0f,0,0);
        }
        else if (player.position.x >= enemy.position.x)
        {
            enemy.velocity = new Vector3(playerX * slowerFactor, 0, 0);
        }

    }
    private bool Grounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void Flip()
    {
        if (faceRight && player.position.x >= enemy.position.x || !faceRight && player.position.x < enemy.position.x)
        {
            faceRight = !faceRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

}
