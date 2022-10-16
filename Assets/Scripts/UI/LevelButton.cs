using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] Sprite On;
    [SerializeField] Sprite Off;

    [SerializeField] Text levelText;

    [SerializeField] GameObject star1;
    [SerializeField] GameObject star2;
    [SerializeField] GameObject star3;
    

    [SerializeField] private bool disabled;

    private void Awake()
    {
        button.image.sprite = Off;
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        disabled = true;
        levelText.text = name == "66" ? "Playground" : name;
        if (PlayerPrefs.HasKey("levelsComplete"))
        {
            if (Convert.ToInt32(name) <= PlayerPrefs.GetInt("levelsComplete") + 1)
            {
                disabled = false;
            }
        }
        else if (Convert.ToInt32(name) == 1)
        {
            disabled = false;
        }
        if (PlayerPrefs.HasKey("level" + name))
        {
            CompleteLevel(PlayerPrefs.GetInt("level" + name));
        }
    }
    public void Unlock()
    {
        disabled = false;
    }
    public void LoadLevel()
    {
        if (!disabled)
        {
            PlayerPrefs.SetInt("level", Convert.ToInt32(name));
            GameMachine.Instance.SwitchState(GameMachine.State.Game);
        }
    }

    public void CompleteLevel(int stars)
    {
        if (stars <= 0 || stars > 3)
        {
            button.image.sprite = Off;
            star1.SetActive(false);
            star2.SetActive(false);
            star3.SetActive(false);
            Debug.LogWarning("Level not passed, number of stars: " + stars);
            return;
        }
        PlayerPrefs.SetInt("level" + name, stars);
        button.image.sprite = On;

        switch (stars)
        {
            case 1: 
                star1.SetActive(true);
                star2.SetActive(false);
                star3.SetActive(false);
                break;
            case 2:
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(false);
                break;
            case 3:
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
                break;
        }
    }
}
