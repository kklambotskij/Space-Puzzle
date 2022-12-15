using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] Sprite On;
    [SerializeField] Sprite Off;

    [SerializeField] Text levelText;

    [SerializeField] GameObject[] stars;

    [SerializeField] private bool disabled;

    private void Awake()
    {
        button.image.sprite = Off;
        button.interactable = false;
        disabled = true;

        stars[0].SetActive(false);
        stars[1].SetActive(false);
        stars[2].SetActive(false);
        
        levelText.text = name == "66" ? "Playground" : name;
        if (PlayerPrefs.HasKey("levelsComplete"))
        {
            if (Convert.ToInt32(name) <= PlayerPrefs.GetInt("levelsComplete") + 1)
            {
                Unlock();
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
        button.interactable = true;
        button.image.sprite = On;
    }
    public void LoadLevel()
    {
        if (!disabled)
        {
            PlayerPrefs.SetInt("level", Convert.ToInt32(name));
            GameMachine.Instance.SwitchState(GameMachine.State.Game);
        }
    }

    public void CompleteLevel(int count)
    {
        if (count <= 0 || count > 3)
        {
            button.image.sprite = Off;
            stars[0].SetActive(false);
            stars[1].SetActive(false);
            stars[2].SetActive(false);
            Debug.LogWarning("Level not passed, number of stars: " + stars);
            return;
        }

        PlayerPrefs.SetInt("level" + name, count);
        button.image.sprite = On;

        for (int i = 0; i < count; i++)
        {
            stars[i].SetActive(true);
        }
    }
}
