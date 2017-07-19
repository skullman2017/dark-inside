using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour {

    public Transform teleportPosition;
    public bool flag = true;

    private Transform initialPosition;
   

    // Use this for initialization
    void Start () {
        initialPosition = this.transform;
    }

    void OnTriggerEnter2D(Collider2D col ) {
        if(col.tag == "Player") {
            if (flag) {
                col.transform.position = teleportPosition.position;
            }
        }
    }

    void OnTriggerExit2D (Collider2D col ) {
        flag = !flag;
    }
 
    


}
