using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSwitch : MonoBehaviour {

    private SpriteRenderer spRenderer;

    public bool flag = false;
    public MovePlatform movePlatform;

    // Use this for initialization
    void Start () {

        spRenderer = GetComponent<SpriteRenderer> ();

        if (movePlatform == null) {
            Debug.Log ("moveplatform not found");
            movePlatform = FindObjectOfType<MovePlatform> ();
        }
    }
    
    // Update is called once per frame
    void Update () {

        if (Input.GetMouseButtonDown (0)) {
            
            RaycastHit2D hit;
            hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero); // raycast from screen point to world point

            if(hit.collider != null) {
                if(hit.collider.gameObject.tag == "Handlebar") {

                    if (movePlatform.canSwitch) {
                        flag = !flag;
                        spRenderer.flipX = flag;

                        if (flag) {
                            movePlatform.moveAtoB ();
                        } else {
                            movePlatform.moveBtoA ();
                        }
                    }

                    //print ("handle bar clicked");
                }
             //   Debug.Log ("clicekd " + hit.collider.gameObject.tag);
            }
        }    

            
    }

}
