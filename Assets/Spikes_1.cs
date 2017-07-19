using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes_1 : MonoBehaviour {

    public GameManager GM;

    // Use this for initialization
    void Start () {
        
    }
    

    void OnTriggerEnter2D ( Collider2D col ) {
        if(col.tag == "Player") {
           
            GM.Respwan (col.gameObject);

        }
    }

}
