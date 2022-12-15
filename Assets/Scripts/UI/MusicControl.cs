using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicControl : MonoBehaviour
{
    [SerializeField] Sprite musicOn;
    [SerializeField] Sprite musicOff;
    [SerializeField] AudioMixer mixer;

    bool music = true;

    private void Start() 
    {
        if(PlayerPrefs.HasKey("music"))
        {
            music = PlayerPrefs.GetFloat("music") >= 0;
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
            PlayerPrefs.SetFloat("music", 0);
            mixer.SetFloat("Music", 0);
        }
        else
        {
            GetComponent<Image>().sprite = musicOff;
            PlayerPrefs.SetFloat("music", -80);
            mixer.SetFloat("Music", -80);
        }
    }
}
