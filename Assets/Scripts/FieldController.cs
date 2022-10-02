using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class FieldController : MonoBehaviour
{
    [SerializeField] public MoveFigurs pink;
    [SerializeField] public MoveFigurs green;
    [SerializeField] public MoveFigurs cyan;
    [SerializeField] public MoveFigurs red;
    [SerializeField] public MoveFigurs yellow;
    [SerializeField] public MoveFigurs orange;
    [SerializeField] public MoveFigurs blue;    
    [SerializeField] Transform content;
    [SerializeField] public Text complicationText;
    [SerializeField] public WinScreen winScreen;
    [SerializeField] public Transform fullField;

    [SerializeField] public Tutorial2 tutorial;

    [SerializeField] public Text percentBestPlayers;

    [SerializeField] public ParticleSystem fireWork;

    [SerializeField] public Shop shop;
    
    public ChangeLevel levels = new ChangeLevel();

    public List<FieldCellLonpos> fieldCellsLonpos = new List<FieldCellLonpos>();

    private int useHelp;
    private int hintPrice = 75;

    public static FieldController Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
        foreach (var item in Camera.main.GetComponentsInChildren<FieldCellLonpos>())
        {
            fieldCellsLonpos.Add(item);
        }
    }
    
    public void Init()
    {
        useHelp = 0;
        InvokeHint();
        UI.Instance.LevelShowButtons();
        if (PlayerPrefs.HasKey("level"))
        {
            levels.levelNumber = PlayerPrefs.GetInt("level");
        }
        else
        {
            levels.levelNumber = 1;
        }
        foreach (var item in fieldCellsLonpos)
        {
            item.GetComponent<FieldCellLonpos>().ChangeBusyCell(false);
            item.gameObject.SetActive(true);
        }
        levels.LevelChanger(this);
        for (int i = 0; i < levels.figurs.Count; i++)
        {
            levels.figurs[i].GetComponent<MoveFigurs>().onField = false;
        }
        //LoadProgress();
    }

    public void InvokeHint()
    {
        CancelInvoke("RemindForHints");
        Invoke("RemindForHints", 10);
    }

    public bool CheckCells()
    {
        int count = 0;
        for (int i = 0; i < levels.figurs.Count; i++)
        {
            if (levels.figurs[i].GetComponent<MoveFigurs>().onField)
            {
                count++;
            }
        }
        if (count == levels.figurs.Count)
        {
            for (int i = 0; i < levels.figurs.Count; i++)
            {
                levels.figurs[i].GetComponent<MoveFigurs>().disabled = true;
            }
            if (levels.levelNumber == 1)
            {
                PlayerPrefs.SetInt("Tutorial", 1);
                tutorial.DisableLock();
            }
            UI.Instance.LevelHideButtons();
            winScreen.Show(5);
            fireWork.Play();

            return true;
        }
        return false;
    }

    public void ClearHints()
    {
        for (int i = 0; i < hints.Count; i++)
        {
            Destroy(hints[i].gameObject);
        }
        hints.Clear();
    }
    public void Complete()
    {
        tutorial.StopHint();

        int lvl = levels.levelNumber;
        int star = useHelp > 0 ? 2 : 3;

        LevelButton levelButton = content.Find(lvl.ToString()).GetComponent<LevelButton>();
        levelButton.CompleteLevel(star);

        PlayerPrefs.SetString("LastPassedLevel", lvl + "-" + (lvl + 1));
        content.Find((lvl + 1).ToString()).GetComponent<LevelButton>().Unlock();
        int maxLvl = lvl;
        if (PlayerPrefs.HasKey("levelsComplete"))
        {
            int savedlvl = PlayerPrefs.GetInt("levelsComplete");
            maxLvl = Mathf.Max(savedlvl, maxLvl);
        }
        PlayerPrefs.SetInt("levelsComplete", maxLvl);

        UI.Instance.ChangeText("");
        GameMachine.Instance.SwitchState(GameMachine.State.Levels);
    }

    public void ResetField()
    {
        foreach (var item in fieldCellsLonpos)
        {
            item.GetComponent<FieldCellLonpos>().ChangeBusyCell(false);
        }
    }

    public void ResetFigurs()
    {
        pink.MoveAway();
        green.MoveAway();
        cyan.MoveAway();
        red.MoveAway();
        yellow.MoveAway();
        orange.MoveAway();
        blue.MoveAway();
    }

    private List<MoveFigurs> hints = new List<MoveFigurs>();

    public void ClickOnHelpButton()
    {
        if (Money.Instance.count >= hintPrice)
        {
            for (int i = 0; i < levels.figurs.Count; i++)
            {
                if (hints.Count > i)
                {
                    continue;
                }
                if (levels.figurs[i].GetComponent<MoveFigurs>().onField)
                {
                    continue;
                }

                GameObject hintObject = Instantiate(levels.figurs[i], fullField);
                hintObject.GetComponent<PolygonCollider2D>().enabled = false;
                hintObject.GetComponent<CircleCollider2D>().enabled = false;
                hintObject.transform.localScale = new Vector3(1, 1, 1);
                hintObject.transform.localEulerAngles = levels.figursRotation[i];

                MoveFigurs move = hintObject.GetComponent<MoveFigurs>();
                move.SetTarget(levels.figursPos[i] + new Vector3(0, -0.25f, 10)); //0.041
                hints.Add(move);
                move.disabled = true;
                move.MakeHint();

                useHelp += 1;
                Money.Instance.SpendMoney(75);
                tutorial.StopHint();
                return;
            }
            
        }
        else
        {
            shop.OpenShop();
            Debug.Log("Недостаточно денег");
        }
    }

    public void RemindForHints()
    {
        UI.Instance.RemindForHints();
    }
    public void SwapFigureCells(int number)
    {
        MoveFigurs[] figurs = new MoveFigurs[] { red, pink, blue, yellow, green, cyan, orange };
        
        for (int i = 0; i < figurs.Length; i++)
        {
            figurs[i].ChangeSkin(number);
        }

        for (int i = 0; i < hints.Count; i++)
        {
            hints[i].ChangeSkin(number);
        }

    }
}
