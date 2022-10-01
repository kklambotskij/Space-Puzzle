using System;
using UnityEngine;
using UnityEngine.SceneManagement;
[Obsolete("Class is deprecated, please use LevelButton instead.")]
public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject On;
    [SerializeField] GameObject Off;

    [SerializeField] GameObject star1;
    [SerializeField] GameObject star2;
    [SerializeField] GameObject star3;

    private bool disabled;

    private void Awake()
    {
        Off.SetActive(true);
        On.SetActive(false);
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        disabled = true;
        GetComponentInChildren<TextMesh>().text = name;
        if (PlayerPrefs.HasKey("levelsComplete"))
        {
            if (Convert.ToInt32(name) <= PlayerPrefs.GetInt("levelsComplete") + 1)
            {
                // 2 levels complete
                // 3 <= 2 + 1
                // 4 <= 2 + 1
                disabled = false;
            }
        }
        else if (Convert.ToInt32(name) == 1)
        {
            disabled = false;
        }
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("level" + name))
        {
            CompleteLevel(PlayerPrefs.GetInt("level" + name));
        }
    }
    private void OnMouseDown()
    {
        if (!disabled)
        {
            PlayerPrefs.SetInt("level", Convert.ToInt32(name));
            GameMachine.Instance.SwitchState(GameMachine.State.Game);
        }
    }

    private void CompleteLevel(int stars)
    {
        if (stars <= 0 || stars > 3)
        {
            Off.SetActive(true);
            On.SetActive(false);
            star1.SetActive(false);
            star2.SetActive(false);
            star3.SetActive(false);
            Debug.LogWarning("Level not passed, number of stars: " + stars);
            return;
        }

        Off.SetActive(false);
        On.SetActive(true);

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
