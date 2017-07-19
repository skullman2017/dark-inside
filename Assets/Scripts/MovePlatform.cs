using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour {

    public Transform pointA;
    public Transform pointB;

    public float speed;
    [HideInInspector]
    public bool canSwitch = true;

    private Coroutine currentRoutine = null;

    // Use this for initialization
    void Start () {
        
        transform.position = pointA.position;
  
       //StartCoroutine (move (pointB.position));

    }



    public IEnumerator move(Vector2 target ) {
        canSwitch = false;

        yield return new WaitForSeconds (1f);
        while(Vector2.Distance(transform.position, target) > 0.5f) {
            
            transform.position = Vector2.Lerp (transform.position, target, Time.deltaTime * speed);
            yield return null;

        }
        canSwitch = true;
    }

    public void moveAtoB ( ) {
        currentRoutine = StartCoroutine (move (pointB.position));
    }

    public void moveBtoA ( ) {
        currentRoutine = StartCoroutine (move (pointA.position));
    }

    public void stopMovement ( ) {
        StopCoroutine (currentRoutine);
    }
    
    void OnCollisionEnter2D(Collision2D other ) {
       /// print (other.gameObject.tag);

        if (other.gameObject.tag == "Player") {
            //StartCoroutine (move (pointB.position));

            other.gameObject.transform.parent = this.transform;
        }
    }

    void OnCollisionExit2D ( Collision2D other ) {
       // print ("exeit");

        if (other.gameObject.tag == "Player") {
      
            other.gameObject.transform.parent = null;
        }
    }


}
