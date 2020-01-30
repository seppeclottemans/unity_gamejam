using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    private bool pickUpAllowed;
    private bool pickUpAllowed2;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(8,9);
    }


    private void OnTriggerEnter2D(Collider2D col){
        
        if(col.gameObject.name.Equals("Player1")){
           pickUpAllowed = true;
        }
        if(col.gameObject.name.Equals("Player2")){
           pickUpAllowed2 = true;
        }
        
    }

    private void PickUp(){
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {     
        if(pickUpAllowed && Input.GetKeyDown(KeyCode.S)){
           PickUp();
        }
        if(pickUpAllowed2 && Input.GetKey(KeyCode.DownArrow)){
           PickUp();
        }
    }
}
