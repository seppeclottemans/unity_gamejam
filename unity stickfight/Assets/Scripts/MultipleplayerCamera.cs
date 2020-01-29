using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleplayerCamera : MonoBehaviour
{
    public List<Transform> targets;

    public Vector3 offset;
 
    void LateUpdate(){

        
        Vector3 centerpoit = GetCenterPoint();

        Vector3 newposition = centerpoit + offset;

        transform.position = newposition;
    }

    Vector3 GetCenterPoint(){
        if(targets.Count == 1){
            return targets[0].position;
        }

        var bounds =  new Bounds(targets[0].position, Vector3.zero);
        for(int i = 0; i < targets.Count; i++){
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.center;
    }
}
