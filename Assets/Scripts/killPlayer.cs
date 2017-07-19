using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPlayer : MonoBehaviour {

    public GameManager GM;

    // Use this for initialization
    void Start () {
        if (GM == null) {
            GM = FindObjectOfType<GameManager> ();
        }
    }
    
    void OnTriggerEnter2D(Collider2D other ) {
        if(other.gameObject.tag == "Player") {
            //print ("player");
            other.gameObject.SetActive (false);

            GM.Respwan (other.gameObject);

        }
    }



} // end 
