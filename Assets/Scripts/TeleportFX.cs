using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportFX : MonoBehaviour {

    public float rotationSpeed = 2f;

    // Use this for initialization
    void Start () {
        
    }
    
    // Update is called once per frame
    void Update () {
        transform.Rotate (new Vector3 (0, 0, 90f * Time.deltaTime*rotationSpeed));

    }

}
