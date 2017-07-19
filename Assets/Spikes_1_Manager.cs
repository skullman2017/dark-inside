using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes_1_Manager : MonoBehaviour {

    private Animator AC;
    public float interval;
    Coroutine coroutine;

    // Use this for initialization
    void Start () {
        AC = GetComponent<Animator> ();

        coroutine = StartCoroutine (enableSpikes ());
        

    }

    IEnumerator enableSpikes ( ) {
        AC.SetBool ("isEnable", false);
       yield return new WaitForSeconds (interval);

        AC.SetBool ("isEnable", true);

        yield return new WaitForSeconds (4f);

       StartCoroutine (enableSpikes ());
    }
    


    
}
