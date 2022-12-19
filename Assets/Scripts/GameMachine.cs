using UnityEngine;

public class GameMachine : MonoBehaviour
{
    public enum State { Levels, Game, Menu, Credits }
    State state;

    [SerializeField] Transform gameCamera;
    [SerializeField] Transform gameCanvas;
    [SerializeField] FieldController fieldController;
    [SerializeField] Transform MainMenu;
    [SerializeField] Transform GameMenu;

    [SerializeField] Transform scrollView;
    [SerializeField] Transform stars;
    [SerializeField] ScrollController scrollController;
    [SerializeField] Transform[] backGrounds;
    [SerializeField] Animator Transition;

    public static GameMachine Instance { get; private set; } // static singleton

    public State currentState;
    void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
        SwitchState(State.Menu, false);

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }
    private void Start()
    {
        if (!PlayerPrefs.HasKey("Tutorial"))
        {
            PlayerPrefs.SetInt("level", 1);
            SwitchState(State.Game);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (currentState == State.Game)
            {
                SwitchState(State.Levels);
            }
            else if (currentState == State.Levels)
            {
                SwitchState(State.Menu);
            }
        }
    }

    State nextState;

    public void SwitchState(State st)
    {
        Transition.SetTrigger("make");
        nextState = st;
    }

    public void LoadNext()
    {
        SwitchState(nextState, true);
    }

    public void SwitchState(State st, bool transition)
    {
        state = st;
        fieldController.ClearHints();
        switch (state)
        {
            case State.Levels:
                GameMenu.gameObject.SetActive(true);
                MainMenu.gameObject.SetActive(false);

                scrollView.gameObject.SetActive(true);
                Camera.main.orthographicSize = 5;

                gameCamera.transform.position = new Vector3(5.79f, 4.46f, -25);
                gameCanvas.gameObject.SetActive(false);
                SwitchBackGround(true);
                if (PlayerPrefs.HasKey("LastPassedLevel"))
                {
                    string level = PlayerPrefs.GetString("LastPassedLevel");
                    stars.Find(level).GetComponent<StarController>().Complete();
                }
                scrollController.UpdateTarget();
                currentState = State.Levels;

                fieldController.ResetField();
                fieldController.ResetFigurs();
                break;
            case State.Game:
                GameMenu.gameObject.SetActive(true);
                MainMenu.gameObject.SetActive(false);

                SwitchBackGround(false);
                scrollView.gameObject.SetActive(false);
                Camera.main.orthographicSize = 8;

                gameCamera.transform.position = new Vector3(5.79f, 4.46f, 0);
                gameCanvas.gameObject.SetActive(true);
                fieldController.Init();
                currentState = State.Game;
                break;
            case State.Menu:
                GameMenu.gameObject.SetActive(false);
                MainMenu.gameObject.SetActive(true);

                SwitchBackGround(false);
                scrollView.gameObject.SetActive(false);
                Camera.main.orthographicSize = 5;

                gameCamera.transform.position = new Vector3(5.79f, 4.46f, -25);
                gameCanvas.gameObject.SetActive(false);
                currentState = State.Menu;
                break;
            case State.Credits:
                GameMenu.gameObject.SetActive(false);
                MainMenu.gameObject.SetActive(false);

                SwitchBackGround(false);
                scrollView.gameObject.SetActive(false);
                Camera.main.orthographicSize = 5;

                gameCamera.transform.position = new Vector3(5.79f, 4.46f, -25);
                gameCanvas.gameObject.SetActive(false);
                currentState = State.Menu;
                break;
            default:
                break;
        }
    }
    private void SwitchBackGround(bool isLevelState)
    {
        if (isLevelState)
        {
            backGrounds[0].gameObject.SetActive(true);
            backGrounds[1].gameObject.SetActive(false);
        }
        else
        {

            backGrounds[0].gameObject.SetActive(false);
            backGrounds[1].gameObject.SetActive(true);
        }
    }
}
