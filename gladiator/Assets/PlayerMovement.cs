using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public GameObject healthBar;
    private float moveH;
    private float jumpPower = 16f;
    private bool faceRight = true;
    private Animator _animator;
    public int maxHealth = 50;
    public int currentHealth;
    public Slider healthSlider;


    [SerializeField] public Rigidbody2D player;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = currentHealth;
        moveH = Input.GetAxisRaw("Horizontal");
        player.velocity = new Vector2(moveH * speed, player.velocity.y);
        Flip();


        if (Input.GetButtonDown("Jump") && Grounded())
        {
            player.velocity = new Vector2(player.velocity.x, jumpPower);
        }
        if (player.velocity.x != 0)
        {
            _animator.SetBool(name: "IsWalking", value: Grounded());
        }
        else
        {
            _animator.SetBool(name: "IsWalking", false);
        }
        Attack();
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

            Vector3 healthLocalScale = healthBar.transform.localScale;
            healthLocalScale.x *= -1f;
            healthBar.transform.localScale = healthLocalScale;
        }
    }
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            _animator.SetTrigger(name: "Attack");
        }
        /*else if (_animator.GetBool(name: "IsAttacking"))
        {
            _animator.SetBool(name: "IsAttacking", value: false);
        }
        */
    }
    private void TakeDamage(int damage)
    {

    }

}
