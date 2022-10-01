using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicControl : MonoBehaviour
{
    [SerializeField] Sprite musicOn;
    [SerializeField] Sprite musicOff;
    bool music = true;

    private void Start() 
    {
        if(PlayerPrefs.HasKey("music"))
        {
            music = PlayerPrefs.GetFloat("music") > 0;
        }
        UpdateLevel();
    }

    public void SwitchLevel()
    {
        music = !music;
        UpdateLevel();
    }

    private void UpdateLevel()
    {
        if(music)
        {
            GetComponent<Image>().sprite = musicOn;
            PlayerPrefs.SetFloat("music", 0.01f);
            Camera.main.GetComponent<AudioSource>().volume = 0.01f;
        }
        else
        {
            GetComponent<Image>().sprite = musicOff;
            PlayerPrefs.SetFloat("music", 0);
            Camera.main.GetComponent<AudioSource>().volume = 0;
        }
    }
}
