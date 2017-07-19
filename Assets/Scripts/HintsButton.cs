using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintsButton : MonoBehaviour {

    public GameObject hintsPanel;
    private bool Flag = true;

    // Use this for initialization
    void Awake () {

        if (hintsPanel == null) {
            hintsPanel = GameObject.Find ("HintsPanel");
                if(hintsPanel == null) {
                    Debug.Log ("Error on Hints button");
                    return;
                }
        }

        hintsPanel.SetActive (false); 

    }
    
    public void tapHitBtn ( ) {
        if (Flag) {
            hintsPanel.SetActive (true);
        } else {
            hintsPanel.SetActive (false);

        }
        Flag = !Flag;

    }

    public void closeBtn ( ) {
        hintsPanel.SetActive (false);
    }


}
