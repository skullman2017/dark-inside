using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    public MySceneManager _sceneManager;
 
    void Awake ( ) {
        DontDestroyOnLoad (this.gameObject);
    }

    // Use this for initialization
    void Start () {
        if (_sceneManager == null) {
            _sceneManager = FindObjectOfType<MySceneManager> ();
        }
    }
    
    
    // respawn player to the last checkpoint 
    public void Respwan (GameObject go ) {
        if (go != null) {
            go.transform.position = Checkpoint.GetActiveCheckPointPosition ();

            // Reset 
            StartCoroutine (Reset (go));

        // go.SetActive (true);
        }
    }


    // this method used to reset camera and other stuff
    IEnumerator Reset ( GameObject player) {
        Vector3 camPos = Checkpoint.GetActiveCheckPointPosition ();
        camPos.z = -10f;
        Camera.main.transform.position = camPos;

        yield return new WaitForSeconds (2f);

        player.SetActive (true);

    }



    public void LOAD_NEXT_LEVEL(){
        _sceneManager.LoadScene (2);
        print("load next level here");
    }

    


}
