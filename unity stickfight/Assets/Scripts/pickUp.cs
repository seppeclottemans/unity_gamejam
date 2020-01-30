using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{
    public GameObject snowPickUp;
    private bool pickGo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col){
        pickGo = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(pickGo && Input.GetKey(KeyCode.S)){
            snowPickUp.SetActive(true);
            Debug.Log("goed");
        }
    }
}
