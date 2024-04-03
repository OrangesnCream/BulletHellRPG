using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private Vector3 offset = new Vector3(0, 0, -10);
    Vector3 target, mousePos, refVel, shakeOffset;
    float cameraDist = 5.0f;
    float smoothTime = 0.2f, zStart;
    private Vector3 velocity = Vector3.zero;

    private bool isToggled = true;

    public bool isBossCamera = false;
    void Start()
    {
        target=player.position;
        zStart = transform.position.z;
    }

    void Update(){
        
    }

    void FixedUpdate(){
        if(isBossCamera){
            Vector3 targetPosition = player.TransformPoint(offset);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
        mousePos = CaptureMousePos();
        if(isBossCamera){
            player = GameObject.FindGameObjectWithTag("BossCamera").transform;
            transform.GetComponent<Camera>().orthographicSize = Mathf.Lerp(transform.GetComponent<Camera>().orthographicSize, 20, 0.01f);
        }
        else{
            target = UpdateTargetPos();
            UpdateCameraPosition();
        }
    }
    Vector3 CaptureMousePos() {
        Vector2 ret = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        ret *= 2;
        ret -= Vector2.one;
        float max = 0.9f;
        if (Mathf.Abs(ret.x)>max||Mathf.Abs(ret.y)>max) {
            ret = ret.normalized;
        }
        return ret;
    }
    Vector3 UpdateTargetPos()
    {
        Vector3 mouseOffset = mousePos * cameraDist;
        Vector3 ret = player.position + mouseOffset;
        ret.z = zStart;
        return ret;
    }
    void UpdateCameraPosition()
    {
        Vector3 tempPos;
        tempPos=Vector3.SmoothDamp(transform.position,target,ref refVel,smoothTime);
        transform.position=tempPos;
    }
}
