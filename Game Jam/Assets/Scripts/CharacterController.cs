using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public Animator animator;

    public float speed;
    public float jumpForce;
    private float moveInput;
    private float timeLog;
    

    public Rigidbody2D rb;

    public bool facingRight = true;

    public static bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpValue;

    void Start()
    {
        extraJumps = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        speed = 5f;
        timeLog = 0;
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        
        if(facingRight == false && moveInput > 0){
            animator.SetBool("facingRight", !facingRight);
            facingRight = !facingRight;
            //Flip();
        }
        else if(facingRight == true && moveInput < 0){
            animator.SetBool("facingRight", !facingRight);
            facingRight = !facingRight;
            //Flip();
        }
    }

    void Update(){
        if(isGrounded == true){
            extraJumps = extraJumpValue;
            timeLog = Time.time;
        }
        Death();
        if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0){
            rb.velocity = Vector2.up * jumpForce;
            --extraJumps;
        }else if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true){
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    void Death(){
        if(isGrounded==false && Time.time - timeLog >3.5 ){
            Energy.energy = 0;
        }
    }
}
