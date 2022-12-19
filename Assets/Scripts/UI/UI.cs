using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] MusicControl Music;
    [SerializeField] SoundControl Sounds;

    [SerializeField] AudioSource starSound;

    [SerializeField] public Transform backButton;
    [SerializeField] public Transform helpButton;
    [SerializeField] public Transform restartButton;
    [SerializeField] public Transform coinsBlock;
    [SerializeField] Text text;

    public static UI Instance { get; private set; } // static singleton

    public Localization local;
    public enum Language { RU, EN }
    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
        SetLocal(Language.EN);
    }
    public void SetLocal(Language lang)
    {
        switch (lang)
        {
            case Language.RU:
                local = new RU();
                break;
            case Language.EN:
                local = new EN();
                break;
        }
    }
    public void ChangeText(string str)
    {
        text.text = str;
    }
    public void Tutorial()
    {
        PlayerPrefs.DeleteKey("Tutorial");
        PlayerPrefs.SetInt("level", 1);
        GameMachine.Instance.SwitchState(GameMachine.State.Levels);
        GameMachine.Instance.SwitchState(GameMachine.State.Game);
    }
    public void StartGame()
    {
        GameMachine.Instance.SwitchState(GameMachine.State.Levels);
    }

    public void Credits()
    {
        GameMachine.Instance.SwitchState(GameMachine.State.Credits);
    }

    public void MainMenuButton()
    {
        GameMachine.Instance.SwitchState(GameMachine.State.Menu);
    }

    public void MusicButton()
    {
        Music.SwitchLevel();
    }

    public void SoundsButton()
    {
        Sounds.SwitchLevel();
    }

    public void BackButton()
    {
        GameMachine.Instance.SwitchState(GameMachine.State.Levels);
    }
    public void RestartLevel()
    {
        GameMachine.Instance.SwitchState(GameMachine.State.Game);
    }
    
    public void LevelHideButtons()
    {
        backButton.gameObject.SetActive(false);
        helpButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        coinsBlock.gameObject.SetActive(false);
    }
    public void LevelShowButtons()
    {
        backButton.gameObject.SetActive(true);
        helpButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        coinsBlock.gameObject.SetActive(true);
    }

    public string GetCongratulation()
    {
        var congrats = local.Greats();
        if (congrats.Length < 1)
        {
            return "Ошибка локализации";
        }
        return congrats[Random.Range(0, congrats.Length)];
    }

    public void RemindForHints()
    {
        helpButton.GetComponent<Animator>().SetTrigger("Pop");
    }

    public void PlayStarSound()
    {
        starSound.Play();
    }
}
