using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelFinishFX : MonoBehaviour {

    private Collider2D col2D;
    public GameObject canvasInputs;
    public GameManager GM;

    // Use this for initialization
    void Start () {
        col2D = GetComponent<Collider2D> ();

        if(canvasInputs==null){
               canvasInputs = GameObject.FindGameObjectWithTag ("Inputs");
        }
        if(GM==null){
            GM = FindObjectOfType<GameManager>();
        }
    }
    

    void OnTriggerEnter2D(Collider2D col ) {
        if (col.tag == "Player") {

            // input remove
            canvasInputs.SetActive(false);
            col.GetComponent<Rigidbody2D> ().gravityScale = 0;
            

            Vector2 dis = col2D.bounds.center;
          
          //   pass handle to GameManager

            StartCoroutine (FX (col.gameObject.transform, dis));
        }
    }

    IEnumerator FX (Transform player, Vector2 dis ) {

        while (Vector2.Distance(player.position, dis )>=0.05f) {
            player.position = Vector2.Lerp (player.position, dis, Time.deltaTime);
            yield return null;

        }

        StartCoroutine (FX2 (player));

    }

    IEnumerator FX2 ( Transform player ) {

        float _scale = 1f;
        int _rot = 1;

        while (_scale > 0) {
            _scale -= 2*Time.deltaTime;
            _rot += 2;

            player.localScale = new Vector2 (_scale, _scale);
            player.localRotation = Quaternion.Euler (0, 0, _rot);

            yield return new WaitForSeconds (0.05f);
        }
        
            player.gameObject.SetActive(false);
            // load next level 
            GM.LOAD_NEXT_LEVEL();
    }


}
