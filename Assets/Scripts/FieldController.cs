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
            Destroy(hints[i]);
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
        var v = new Vector3(0, 10, 0);
        pink.SetTarget(v);
        green.SetTarget(v);
        cyan.SetTarget(v);
        red.SetTarget(v);
        yellow.SetTarget(v);
        orange.SetTarget(v);
        blue.SetTarget(v);
    }

    public void HideFigurs()
    {
        for (int i = 0; i < levels.figurs.Count; i++)
        {
            levels.figurs[i].SetActive(false);
        }
    }

    List<MoveFigurs> hints = new List<MoveFigurs>();

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
                move.PingPong();

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
        //SaveProgress();
    }

    public void RemindForHints()
    {
        UI.Instance.RemindForHints();
    }

    void Capture()
    {
        ScreenCapture.CaptureScreenshot("Screenshot" + System.DateTime.Now.Hour + System.DateTime.Now.Minute + System.DateTime.Now.Second + ".png");
        string filePath = Application.persistentDataPath + "/" + levels.levelNumber.ToString() + ".txt";
        try
        {
            string[] data = new string[7];
            data[0] = "pink : " + pink.transform.position.ToString() + " " + pink.transform.rotation.eulerAngles.ToString();
            data[1] = "green : " + green.transform.position.ToString() + " " + green.transform.rotation.eulerAngles.ToString();
            data[2] = "cyan : " + cyan.transform.position.ToString() + " " + cyan.transform.rotation.ToString();
            data[3] = "red : " + red.transform.position.ToString() + " " + red.transform.rotation.ToString();
            data[4] = "yellow : " + yellow.transform.position.ToString() + " " + yellow.transform.rotation.ToString();
            data[5] = "orange : " + orange.transform.position.ToString() + " " + orange.transform.rotation.ToString();
            data[6] = "blue : " + blue.transform.position.ToString() + " " + blue.transform.rotation.ToString();
            File.WriteAllLines(filePath, data);
            print(filePath);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public void SaveProgress()
    {
        for (int i = 0; i < levels.figurs.Count; i++)
        {
            PlayerPrefs.SetInt("savedLevel", levels.levelNumber);
            PlayerPrefs.SetFloat(levels.figurs[i].name + "x", levels.figurs[i].transform.position.x);
            PlayerPrefs.SetFloat(levels.figurs[i].name + "y", levels.figurs[i].transform.position.y);
            PlayerPrefs.SetFloat(levels.figurs[i].name + "z", levels.figurs[i].transform.position.z);

            PlayerPrefs.SetFloat(levels.figurs[i].name + "rx", levels.figurs[i].transform.rotation.x);
            PlayerPrefs.SetFloat(levels.figurs[i].name + "ry", levels.figurs[i].transform.rotation.y);
            PlayerPrefs.SetFloat(levels.figurs[i].name + "rz", levels.figurs[i].transform.rotation.z);
            PlayerPrefs.SetFloat(levels.figurs[i].name + "rw", levels.figurs[i].transform.rotation.w);

            if (levels.figurs[i].transform.localScale.x == 1)
            {
                PlayerPrefs.SetFloat(levels.figurs[i].name + "size", 1);
            }
            else
            {
                PlayerPrefs.SetFloat(levels.figurs[i].name + "size", 0.5f);
            }
        }
    }

    public void LoadProgress()
    {
        if (!PlayerPrefs.HasKey("savedLevel")) { return; }
        if (PlayerPrefs.GetInt("savedLevel") != levels.levelNumber) { return; }
        for (int i = 0; i < levels.figurs.Count; i++)
        {
            float x = PlayerPrefs.GetFloat(levels.figurs[i].name + "x");
            float y = PlayerPrefs.GetFloat(levels.figurs[i].name + "y");
            float z = PlayerPrefs.GetFloat(levels.figurs[i].name + "z");
            levels.figurs[i].transform.position = new Vector3(x, y, z);
            x = PlayerPrefs.GetFloat(levels.figurs[i].name + "rx");
            y = PlayerPrefs.GetFloat(levels.figurs[i].name + "ry");
            z = PlayerPrefs.GetFloat(levels.figurs[i].name + "rz");
            float w = PlayerPrefs.GetFloat(levels.figurs[i].name + "rw");
            levels.figurs[i].transform.rotation = new Quaternion(x, y, z, w);

            if (PlayerPrefs.HasKey(levels.figurs[i].name + "size"))
            {
                float size = PlayerPrefs.GetFloat(levels.figurs[i].name + "size");
                levels.figurs[i].transform.localScale = new Vector3(size, size, size);
            }
            levels.figurs[i].GetComponent<MoveFigurs>().CheckForMatch();
        }
    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteKey("savedLevel");
        string[] figurs = { "Red", "Pink", "Yellow", "Cyan", "Orange", "Blue", "Green" };
        for (int i = 0; i < figurs.Length; i++)
        {
            PlayerPrefs.DeleteKey("savedLevel");
            PlayerPrefs.DeleteKey(figurs[i] + "x");
            PlayerPrefs.DeleteKey(figurs[i] + "y");
            PlayerPrefs.DeleteKey(figurs[i] + "z");

            PlayerPrefs.DeleteKey(figurs[i] + "rx");
            PlayerPrefs.DeleteKey(figurs[i] + "ry");
            PlayerPrefs.DeleteKey(figurs[i] + "rz");
            PlayerPrefs.DeleteKey(figurs[i] + "rw");

            PlayerPrefs.DeleteKey(figurs[i] + "size");
        }

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
