using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {


    public Transform target;


    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public float downStopPos = -2f; 


    void LateUpdate ( ) {
        if (target.gameObject.activeInHierarchy) {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            if (transform.position.y<downStopPos) {
                smoothedPosition.y = downStopPos;
                transform.position = smoothedPosition;
            }

        }
    }



}
