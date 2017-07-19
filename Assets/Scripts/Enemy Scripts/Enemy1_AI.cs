using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1_AI : MonoBehaviour {

    public enum State {
        Idle,
       Attack,
       Die
    }
    public State state;
    public AnimationCurve AC;
    public LayerMask playerLayer;
    [Tooltip("Speed Modifier")]
    public float time = 8f; //speed modifier 

    private Animator ac;
    private Coroutine mycoroutine;
    private Vector2 target; // the player 
    private GameObject theplayer;

    public bool inRange = false;
    public float sightDistance = 6f;


    // Use this for initialization
    void Start () {
        ac = GetComponent<Animator> ();

        NextState ();

    }
    
    void NextState ( ) {
        // code goes here 
        string methodName = state.ToString ();
        
        StartCoroutine (methodName);
    }

    void Update ( ) {
        Enemy_Sensor ();

    }

    public void Enemy_Sensor ( ) {
        RaycastHit2D hit = Physics2D.Raycast (transform.position, -transform.right, sightDistance, playerLayer);
        if (hit.collider != null && hit.collider.tag == "Player") {
            state = State.Attack;

            target = new Vector2 (hit.collider.transform.position.x, this.transform.position.y);
            theplayer = hit.collider.gameObject;

            inRange = true;
            //print ("inRange : " + hit.collider.tag);

        } else {
            target = Vector2.zero;
            state = State.Idle;
            inRange = false;
        }
    }

    // actuator 
    public IEnumerator Idle ( ) {
        while (state == State.Idle) {
            ac.SetBool ("inRange", false);

           // Debug.Log ("Idle State");
            yield return null;
        }

        // change state
        NextState ();
    }


    // actuator
    public IEnumerator Attack ( ) {
        float timer = 0f;

        while(state == State.Attack) {
            ac.SetBool ("inRange", true);

            while (Vector2.Distance (transform.position, target) > 0.5f && state == State.Attack) {
                #region attactPlayer
                   transform.position  = Vector2.MoveTowards(transform.position, target, AC.Evaluate(timer/time));
                   timer += Time.deltaTime;
                yield return null;
                #endregion
              //  Debug.Log ("Attack State");
            }

            theplayer.GetComponent<PlayerController> ().enabled = false;
            yield return new WaitForSeconds (2f);
            break;
            
        }
        state = State.Die;
        
        // change state 
        NextState ();

    }


    public IEnumerator Die ( ) {
        while(state == State.Die) {
          
            
            theplayer.SetActive (false);

            //theplayer.GetComponent<PlayerController> ().enabled = true;
            //Destroy (this.gameObject);

            yield return null;
        }
        
        //StopCoroutine (mycoroutine);

    }

    void OnDrawGizmos ( ) {
        Debug.DrawRay (transform.position, -transform.right*sightDistance, Color.green);

    }


}
