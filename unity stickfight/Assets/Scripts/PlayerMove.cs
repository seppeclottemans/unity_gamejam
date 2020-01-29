using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sr;

    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake(){
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    void move(){
        float h = Input.GetAxisRaw("Horizontal");
        Vector3 temp = transform.position;
        if(h > 0 ){
            temp.x += speed* Time.deltaTime;
            sr.flipX = false;
        }else if(h < 0){
            temp.x -= speed * Time.deltaTime;
            sr.flipX = true;
        }
        transform.position = temp;
    }

    // Update is called once per frame
    void Update()
    {
        move(); 
    }
}
