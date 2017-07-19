using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation_1 : MonoBehaviour {

    public Transform teleportPos;

    public bool _flag = false;

    // Use this for initialization
    void Start () {
        
    }
    
    
    void OnTriggerEnter2D(Collider2D col ) {
        if(col.tag == "Player") {
            if (_flag) {
                col.transform.position = teleportPos.position;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col ) {
        _flag = !_flag;
        print ("exit");
    }


}
