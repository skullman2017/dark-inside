using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour {

    public GameObject LoadingScreen;
    public Slider loadingBar;


    // Use this for initialization
    void Start () {
     
    }

    public void LoadScene ( int sceneID ) {
        StartCoroutine (LoadAsync (sceneID));

    }

    IEnumerator LoadAsync ( int sceneID ) {
        AsyncOperation operation = SceneManager.LoadSceneAsync (sceneID);

        LoadingScreen.SetActive (true);


        while (!operation.isDone) {
            float progress = Mathf.Clamp01 (operation.progress / 0.9f);

            loadingBar.value = progress;
            yield return null;
        }

    }


    public void GameToMenu ( ) {
        // main meny scene ID is 0
        StartCoroutine (LoadAsync (0));
        SumPause.Status = false;
    }

    public void QuiteGame ( ) {
        Application.Quit ();
    }


}
