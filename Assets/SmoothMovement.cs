using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
attach the script on a gameObject, set the animation curve 
*/
public class SmoothMovement : MonoBehaviour {

    public AnimationCurve AC;
    private Vector2 pos1 = new Vector2 (-4, 0);
    private Vector2 pos2 = new Vector2 (4, 0);


    // Use this for initialization
    void Start () {
        StartCoroutine (Move (pos1, pos2, AC, 3.0f));
    }

    IEnumerator Move ( Vector3 pos1, Vector3 pos2, AnimationCurve ac, float time ) {
        float timer = 0.0f;
        while (timer <= time) {
            transform.position = Vector3.Lerp (pos1, pos2, ac.Evaluate (timer / time));
            timer += Time.deltaTime;
            yield return null;
        }
    }

    /*
        float startTime = Time.time;
        float duration = 10 secs;
        while (Time.time - startTime < duration)
        {
        // code goes here
        ]

    */

}
