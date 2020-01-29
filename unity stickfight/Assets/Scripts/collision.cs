using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(8,9);
    }


    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.name == "snowBall"){
            Debug.Log("GOED");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
