using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MultipleplayerCamera : MonoBehaviour
{
    public List<Transform> targets;
    public float smoothTime = .5f;
    public float minZoom = 40f;
    public float maxZoom = 14f;
    public float zoomLimiter = 50f;
    public bool bounds;
    public Vector3 offset;
    public Vector3 minCamPos;
    public Vector3 maxCamPos;
    private Vector3 velocity;
    private Camera cam;

    void Start(){
        cam = GetComponent<Camera>();
    }
 
    void LateUpdate(){
        if(targets.Count == 0)
            return;
        
        Move();
        Zoom();
    }

    void Move(){
        Vector3 centerpoit = GetCenterPoint();

        Vector3 newposition = centerpoit + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newposition, ref velocity, smoothTime);

        if(bounds){
            transform.position =  new Vector3(Mathf.Clamp(transform.position.x, minCamPos.x, maxCamPos.x),
            Mathf.Clamp(transform.position.y, minCamPos.y, maxCamPos.y),
            Mathf.Clamp(transform.position.z, minCamPos.z, maxCamPos.z));
        }
    }

    float GetGreatestDistance(){
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for(int i = 0; i < targets.Count; i++){
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.size.x;
    }

    void Zoom(){
       float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
       cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
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
