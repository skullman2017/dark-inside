using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

[RequireComponent (typeof(Rigidbody2D)) ]	
[RequireComponent (typeof(BoxCollider2D)) ]
public class PlayerController : MonoBehaviour {

    public struct playerState{
        public bool grounded, moveLeft, moveRight, onAir, swing;
    }

    public float movementSpeed = 5f;
    public float jumpForce = 5f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float distanceToGround = 0.2f;
    public LayerMask staticCollider;
    public playerState state;



    [Space(10)]
    private Rigidbody2D rBody;
    public Transform leftmost;
    public Transform rightmost;

    Collider2D[] platforms = new Collider2D[2];

    [HideInInspector]
    public int hrInput = 0;

    private SpriteRenderer sp;

    [HideInInspector]
    public static Animator ac;

    void Awake ( ) {
        Application.targetFrameRate = 60;
    }

    // Use this for initialization
    void Start ( ) {
        rBody = GetComponent<Rigidbody2D> ();
        ac = GetComponent<Animator> ();
        sp = GetComponent<SpriteRenderer> ();

        state.grounded = false;
        state.moveLeft = false;
        state.moveRight = false;
        state.onAir = false;
        state.swing = false;
    }
    
    void Update ( ) {
        state.grounded = isGrounded ();

        if (state.grounded) {
            state.onAir = false;
        } else {
            state.onAir = true;
        }
        //// print(state.grounded);
        BetterJump ();

        hrInput = (int)CnInputManager.GetAxis ("Horizontal");


        ac.SetInteger ("hrInput", hrInput);

        if (state.onAir)
            ac.SetBool ("Jump", true);
        else if(state.onAir==false)
            ac.SetBool ("Jump", false);

        if (hrInput == 0) {
            sp.flipX = false;
        }
     
    }

    //FixedUpdate is framerate independent, and therefore completely unrelated to your framerate

    void FixedUpdate ()
    {
  
        if (hrInput > 0) {
            MOVE_RIGHT ();
        } else if (hrInput < 0) {
            MOVE_LEFT ();
        } else {
            STOP_MOVE ();

        }

        if (CnInputManager.GetButtonDown ("Jump")) {
            //  print ("jump");
            JUMP ();
        }

    }


    public bool isGrounded(){
       // print ("ground");
        if (Physics2D.OverlapAreaNonAlloc (leftmost.position, rightmost.position, platforms, staticCollider) > 0) {
            return true;
        } else
            return false;
    }

    void OnDrawGizmos() {
       // Debug.DrawRay (transform.position, Vector2.up, Color.red);
        
        Gizmos.color = Color.red;
        Gizmos.DrawLine(leftmost.position, rightmost.position);
    }

    public void setHrInput (int h ) {
        hrInput = h;
    }

    public void JUMP(){
        if(state.grounded){
            //ac.SetBool ("Jump", true);
            rBody.velocity = Vector2.up * jumpForce;
        } 
    }

    public void MOVE_LEFT(){
        sp.flipX = true;
        rBody.velocity = new Vector2 (-1 * movementSpeed, rBody.velocity.y);
    }

    public void MOVE_RIGHT(){
        sp.flipX = false;
        rBody.velocity = new Vector2(1 * movementSpeed, rBody.velocity.y);
    }

    public void STOP_MOVE(){
        rBody.velocity = new Vector2(0,rBody.velocity.y);
    }


    void BetterJump(){
        if(rBody.velocity.y<0){   // falling down 
            rBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier-1)*Time.fixedDeltaTime;
        }else if(rBody.velocity.y>0 && !CnInputManager.GetButtonDown ("Jump")) {
            rBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier-1)*Time.fixedDeltaTime;
        }
    }



  


} // end 
