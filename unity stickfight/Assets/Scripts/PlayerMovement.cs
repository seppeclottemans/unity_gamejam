using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sr;

    public KeyCode left;
    public KeyCode right;

    public KeyCode jump;
    private Rigidbody2D theRB;

    public float speed;
    public float jumpForce;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
    }
    void Awake(){
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if(Input.GetKey(left)){
             theRB.velocity = new Vector2(-speed, theRB.velocity.y);
             anim.SetBool("run", true);
             sr.flipX = true;
        }else if (Input.GetKey(right)){
            theRB.velocity = new Vector2(speed, theRB.velocity.y);
            anim.SetBool("run", true);
            sr.flipX = false;
        }else{
            theRB.velocity = new Vector2(0, theRB.velocity.y);
            anim.SetBool("run", false);
        }

        if(Input.GetKeyDown(jump) && isGrounded){
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }
        
    }
}
