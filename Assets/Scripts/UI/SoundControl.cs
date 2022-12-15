using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    [SerializeField] Sprite soundOn;
    [SerializeField] Sprite soundOff;
    [SerializeField] AudioMixer mixer;

    bool sound = true;

    private void Start() 
    {
        if(PlayerPrefs.HasKey("sounds"))
        {
            sound = PlayerPrefs.GetFloat("sounds") >= 0;
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
            PlayerPrefs.SetFloat("sounds", 0);
            mixer.SetFloat("Sounds", 0);
        }
        else
        {
            GetComponent<Image>().sprite = soundOff;
            PlayerPrefs.SetFloat("sounds", 0);
            mixer.SetFloat("Sounds", -80);
        }
    }
}
