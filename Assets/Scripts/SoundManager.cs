using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {

    public Image _Image;
    public Sprite soundOffSprite;

    private bool flag = true;
    private Sprite soundOnSprite;

    // Use this for initialization
    void Start () {

        soundOnSprite = _Image.sprite;
    }
    

    public void SoundOnOFF ( ) {
        flag = !flag;
        if (!flag) {
            _Image.sprite = soundOffSprite;
        } else if(flag){
            _Image.sprite = soundOnSprite;
        }
    }




}
