using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour {

    // Use this for initialization
    void Start () {
        
    }
    

    void OnTriggerEnter2D(Collider2D col ) {
        if(col.gameObject.tag == "Player") {
            this.gameObject.SetActive (false);
        }
    }


}
