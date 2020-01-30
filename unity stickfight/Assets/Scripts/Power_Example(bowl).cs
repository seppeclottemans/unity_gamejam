using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bowl : MonoBehaviour
{
    bool hasBoweled = false;
    float power;
    public Image powerImage;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if(!hasBoweled){
            if(Input.GetKey(KeyCode.Space)){
                power ++;
                powerImage.rectTransform.sizeDelta = new Vector2(40, power);
            }

            if(Input.GetKeyUp(KeyCode.Space)){
                rb.AddForce(new Vector3(0,0,power));
                hasBoweled = true;
            }
        }

        if(Input.GetKey(KeyCode.LeftArrow)){
            rb.AddTorque(new Vector3(0,0,10f),ForceMode.Force);
        }else if(Input.GetKey(KeyCode.RightArrow)){
            rb.AddTorque(new Vector3(0,0,-10f),ForceMode.Force);
        }
    }
}
