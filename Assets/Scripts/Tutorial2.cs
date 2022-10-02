using UnityEngine;

public class Tutorial2 : MonoBehaviour
{
    [SerializeField] private GameObject pal;
    private Animator animator;
    private MoveFigurs move;
    private MoveFigurs pink;

    private bool figureMove;
    private bool active;
    private bool pinkPlaced;

    private void Start()
    {
        animator = GetComponent<Animator>();
        pink = FieldController.Instance.pink;
        pinkPlaced = true;
    }
    public void StartTutorial()
    {
        StopTutorial();
        pinkPlaced = false;
        UI.Instance.touchBlock.gameObject.SetActive(false);
        UI.Instance.LevelHideButtons();
        
        move = pink;
        FieldController.Instance.ResetField();
        animator.SetTrigger("Start");
        pal.SetActive(true);
        figureMove = false;
        active = true;

        if (!PlayerPrefs.HasKey("Tutorial"))
        {
            Money.Instance.GetMoney(-99999999);
        }
    }

    public void StopTutorial()
    {
        animator.SetTrigger("Reset");
        figureMove = false;
        active = false;
        pal.transform.position = new Vector3(-10, -20, -10);
        pal.SetActive(false);

        ResetField();
    }

    public void UseHint()
    {
        move = null;
        if (!PlayerPrefs.HasKey("Tutorial"))
            DailyReward.count = 100;
        UI.Instance.helpButton.gameObject.SetActive(true);
        UI.Instance.ChangeText(UI.Instance.local.UseHint());
        UI.Instance.helpButton.GetComponent<Animator>().SetTrigger("Pop");
    }

    public void DisableLock()
    {

    }

    public void StopHint()
    {
        if (FieldController.Instance.levels.levelNumber == 1)
        {
            UI.Instance.ChangeText(UI.Instance.local.FillTheBoard());
        }
        UI.Instance.helpButton.GetComponent<Animator>().SetTrigger("Stop");
    }

    public void RotateMove()
    {
        move.Rotate();
    }

    public void TakeMove()
    {
        figureMove = true;
    }

    public void ScaleUp()
    {
        move.ScaleUp();
    }

    public void MatchMove()
    {
        figureMove = false;
        move.CheckForMatch();
    }

    public void ResetField()
    {
        pink.SetTarget(new Vector3(-2.1f, -5f, 9));
        pink.transform.rotation = new Quaternion(0, 0, 0, 0);
        pink.transform.localScale = new Vector3(0.5f, 0.5f, 1);
    }

    private void Update()
    {
        if (figureMove)
        {
            var v = pal.transform.position;
            move.SetTarget(new Vector3(v.x, v.y + 1, 0), false);
        }
        if (Input.touches.Length > 0 )
        {
            if (active)
            {
                StopTutorial();
            }
            else if (!pinkPlaced && pink.onField)
            {
                UseHint();
                pinkPlaced = true;
            }
        }
    }
}
