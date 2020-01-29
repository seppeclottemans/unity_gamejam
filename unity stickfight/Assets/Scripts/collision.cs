using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    public KeyCode pickUp;
    // Start is called before the first frame update
    void Start()
    {
    Physics2D.IgnoreLayerCollision(8,9);
    }


    void OnTriggerEnter2D(Collider2D col){
        
        if(col.gameObject.name == "snowBall"){
            Destroy(col.gameObject);
            
            
        }
        
    }


    // Update is called once per frame
    void Update()
    {       
    }
}
