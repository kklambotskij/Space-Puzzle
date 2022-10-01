using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    [SerializeField] Sprite soundOn;
    [SerializeField] Sprite soundOff;
    bool sound = true;

    private void Start() 
    {
        if(PlayerPrefs.HasKey("sounds"))
        {
            sound = PlayerPrefs.GetFloat("sounds") > 0;
        }
        UpdateLevel();
    }

    public void SwitchLevel()
    {
        sound = !sound;
        UpdateLevel();
    }

    private void UpdateLevel()
    {
        if(sound)
        {
            GetComponent<Image>().sprite = soundOn;
            PlayerPrefs.SetFloat("sounds", 0.5f);
        }
        else
        {
            GetComponent<Image>().sprite = soundOff;
            PlayerPrefs.SetFloat("sounds", 0);
        }
    }
}
