using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0, 0, -10);
    private float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    private bool isToggled = true;

    public bool isBossCamera = false;

    [SerializeField] private Transform target;

    void Update(){
        if(Input.GetKeyDown(KeyCode.C)){
            isToggled = !isToggled;
        }

        if(Input.GetKeyDown(KeyCode.B)){
            Debug.Log("Toggling boss camera");
            isBossCamera = !isBossCamera;
        }

        if(isBossCamera){
            target = GameObject.FindGameObjectWithTag("BossCamera").transform;
            transform.GetComponent<Camera>().orthographicSize = Mathf.Lerp(transform.GetComponent<Camera>().orthographicSize, 20, 0.01f);
        }
        else{
            target = GameObject.FindGameObjectWithTag("Player").transform;
            transform.GetComponent<Camera>().orthographicSize = Mathf.Lerp(transform.GetComponent<Camera>().orthographicSize, 10, 0.001f);
        }
    }

    void FixedUpdate(){
        if(isToggled){
            Vector3 targetPosition = target.TransformPoint(offset);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
