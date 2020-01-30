using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sr;

    public KeyCode right;

    public KeyCode left;

    public KeyCode jump;

    public float speed;
    public float jumpForce;

    public bool isGrounded = false;

    public Transform groundCheckPoint;

    public float groundCheckRadius;
    public LayerMask whatIsGround;

    private Rigidbody2D rb;

  
    // Start is called before the first frame update
    void Start(){

        rb = GetComponent<Rigidbody2D>();
    }
    void Awake(){
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position,groundCheckRadius, whatIsGround);
        Move();
        
    }

    void Move(){
       
        Vector3 temp = transform.position;
        if(Input.GetKey(right)){
            temp.x += speed * Time.deltaTime;
            anim.SetBool("run", true);
            sr.flipX = false;
        }else if (Input.GetKey(left)){
            temp.x -= speed * Time.deltaTime;
            anim.SetBool("run", true);
            sr.flipX = true;
        }else{
            anim.SetBool("run", false);
        }
        transform.position = temp;

        if( isGrounded && Input.GetKey(jump)){
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            
        }
    }

}
