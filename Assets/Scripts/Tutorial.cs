using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject pal;

    private Animator animator;
    private MoveFigurs move;
    private float timer = 0;
    private bool unlock = false;
    private bool figureMove = false;
    private bool figurePlaced = false;
    public void StartTutorial()
    {
        animator = GetComponent<Animator>();

        ResetTutorial();
        UI.Instance.touchBlock.gameObject.SetActive(false);
        UI.Instance.LevelHideButtons();
        PlayerPrefs.SetFloat("sounds", 0.5f);
        PlayerPrefs.SetFloat("music", 0.01f);

        move = FieldController.Instance.blue.GetComponent<MoveFigurs>();
        move.disabled = true;
        pal.SetActive(true);

        FieldController.Instance.yellow.GetComponent<MoveFigurs>().disabled = true;
        FieldController.Instance.pink.GetComponent<MoveFigurs>().disabled = true;
        FieldController.Instance.ResetField();

        UI.Instance.ChangeText(UI.Instance.local.TapTileToRotate());
        AddEvent("TapOn", 3);
        AddEvent("FingerDown", 1);
        AddEvent("Move", 1, "ScaleUp", 1.5f);
        AddEvent("Confirm", 1, "FingerUp", 1);
        AddEvent("RepeatBlue", 1.5f);
    }

    public void RestartTutorial()
    {
        if (figurePlaced)
        {
            return;
        }
        timer = 0;
        unlock = false;
        figureMove = false;
        figurePlaced = false;
        FieldController.Instance.levels.ResetBlue();
        var blue = FieldController.Instance.blue.GetComponent<MoveFigurs>();
        blue.onField = false;
        blue.disabled = false;
        StartTutorial();
    }

    public void SecondPart()
    {
        timer = 0;
        unlock = false;
        move = null;
        figurePlaced = true;
        UI.Instance.restartButton.gameObject.SetActive(true);
        UI.Instance.coinsBlock.gameObject.SetActive(true);
        FieldController.Instance.pink.GetComponent<MoveFigurs>().disabled = false;
        FieldController.Instance.yellow.GetComponent<MoveFigurs>().disabled = false;
        UI.Instance.helpButton.gameObject.SetActive(true);
        UseHint();
    }

    public void DisableLock()
    {
        UI.Instance.restartButton.gameObject.SetActive(true);
        UI.Instance.backButton.gameObject.SetActive(true);
    }
    public void ResetTutorial()
    {
        GetComponent<Animator>().SetTrigger("Reset");
        pal.transform.position = new Vector3(2.35142827f, -6.05844688f, 0);
        pal.SetActive(false);
    }
    public void StopHint()
    {
        if (FieldController.Instance.levels.levelNumber == 1)
        {
            UI.Instance.ChangeText(UI.Instance.local.FillTheBoard());
        }
        UI.Instance.helpButton.GetComponent<Animator>().SetTrigger("Stop");
    }
    public void UseHint()
    {
        UI.Instance.ChangeText(UI.Instance.local.UseHint());
        UI.Instance.helpButton.GetComponent<Animator>().SetTrigger("Pop");
    }

    void RepeatBlue()
    {
        FieldController.Instance.levels.ResetBlue();
        Invoke("Unlock", 0.2f);
        Invoke("RestartTutorial", 10);
    }

    void Unlock()
    {
        var blue = FieldController.Instance.blue.GetComponent<MoveFigurs>();
        blue.circle.enabled = true;
        blue.disabled = false;
        blue.onField = false;
        unlock = true;
    }

    void TapOn()
    {
        animator.SetTrigger("Tap");
    }

    void FingerDown()
    {
        animator.SetTrigger("Down");
    }

    void FingerUp()
    {
        animator.SetTrigger("Up");
    }

    public void Rotate()
    {
        move.Rotate();
    }
    void Move()
    {
        figureMove = true;
        animator.SetTrigger("Move");
    }
    void ScaleUp()
    {
        move.ScaleUp();
    }
    void Confirm()
    {
        figureMove = false;
        move.CheckForMatch();
    }
    
    public void AddEvent(string function, float delay)
    {
        Invoke(function, timer + delay);
        timer += delay;
    }
    public void AddEvent(string function1, float delay1, string function2, float delay2)
    {
        Invoke(function1, timer + delay1);
        Invoke(function2, timer + delay2);
        timer += Mathf.Max(delay1, delay2);
    }
    void Update()
    {
        if (figureMove)
        {
            var v = pal.transform.position;
            move.SetTarget(new Vector3 (v.x, v.y + 1, 0), false);
        }
        if (Input.GetMouseButtonUp(0) && unlock)
        {
            if (FieldController.Instance.blue.GetComponent<MoveFigurs>().onField)
            {
                SecondPart();   
            }
        }
    }
}
