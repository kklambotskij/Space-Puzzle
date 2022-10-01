using System.Collections.Generic;
using UnityEngine;
public class MoveFigurs : MonoBehaviour
{
    [SerializeField] AudioSource rotate;
    [SerializeField] AudioSource magnet;

    [SerializeField] public List<Transform> cells;
    [SerializeField] private SkinChanger[] cellSkins;

    [SerializeField] List<FieldCellLonpos> fieldCells;

    public bool disabled;
    public bool dark;
    public bool onField;
    public CircleCollider2D circle;

    public bool shadow = false;

    private static float zIndex = 0;
    private Vector3 pivotOffset = new Vector3(0, 1, -9);
    
    Color baseColor;
    Color fieldCellsColor = new Color(255, 255, 255);

    [SerializeField] private Vector3 pastPosition;
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private Vector3 startPosition;

    private float positionDelay = 0.25f;
    private float positionTimer = 0;

    private bool touchDidMove = false;
    private float tapTimeThreshold = 0.3f;
    private float tapTime = 0;

    private void Start()
    {
        pastPosition = transform.position;
        circle = GetComponent<CircleCollider2D>();
        cellSkins = GetComponentsInChildren<SkinChanger>();
    }

    public void SetTarget(Vector3 target, bool lerp = true)
    {
        if (lerp)
        {
            ResetLerp();
        }
        targetPosition = target;
    }

    public void SetStartPos()
    {
        startPosition = targetPosition;
    }

    private void ResetLerp()
    {
        positionTimer = 0;
        pastPosition = transform.position;
    }

    public void OnMouseDown()
    {
        if (!disabled)
        {
            tapTime = 0;
            touchDidMove = false;
            ResetLerp();
            CheckFieldCell();
            onField = false;
#warning remove this shit
            float volume = PlayerPrefs.GetFloat("sounds");
            rotate.volume = volume;
            magnet.volume = volume;

            circle.enabled = true;
        }
    }
    public void OnMouseDrag()
    {
        if (!disabled)
        {
            if (Input.touches.Length > 0)
            {
                var touch = Input.touches[0];
                tapTime += Time.deltaTime;
                if (touch.phase == TouchPhase.Moved || touchDidMove == true)
                {
                    touchDidMove = true;
                }
                else if (touch.phase == TouchPhase.Stationary && tapTime <= tapTimeThreshold)
                {
                    touchDidMove = false;
                    return;
                }
            }
            var v = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zIndex - 0.01f));
            targetPosition = new Vector3(v.x, v.y, pastPosition.z) + pivotOffset;
            ScaleUp();
            if (Check())
            {
                baseColor = cells[0].GetComponentInChildren<SpriteRenderer>().color;
                for (int i = 0; i < fieldCells.Count; i++)
                {
                    SpriteRenderer hintRenderer = fieldCells[i].GetComponentInChildren<SpriteRenderer>();
                    hintRenderer.color = baseColor;
                }
            }
        }
    }
    public void OnMouseUp()
    {
        if (!disabled)
        {
            if (tapTime <= tapTimeThreshold && touchDidMove == false)
            {
                Rotate();
            }
            CheckForMatch();
            //Camera.main.GetComponent<FieldController>().SaveProgress();
        }
    }

    public void Rotate()
    {
        rotate.Play();
        transform.Rotate(new Vector3(0, 0, 1), 60);
    }
    public void ScaleUp()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }
    public void CheckFieldCell()
    {
        for (int i = 0; i < fieldCells.Count; i++)
        {
            fieldCells[i].ChangeBusyCell(false);
        }
    }

    public void CheckForMatch()
    {
        Match(Check());
    }

    public void ClearFieldCells()
    {
        for (int i = 0; i < fieldCells.Count; i++)
        {
            SpriteRenderer hintRenderer = fieldCells[i].GetComponentInChildren<SpriteRenderer>();
            hintRenderer.color = fieldCellsColor;
        }
        fieldCells.Clear();
    }

    public bool Check()
    {
        ClearFieldCells();
        int count = 0;

        for (int i = 0; i < cells.Count; i++)
        {
            RaycastHit2D hit = Physics2D.GetRayIntersection(new Ray(cells[i].position, new Vector3(0, 0, 10)));
            if (hit)
            {
                if (hit.collider.CompareTag("FieldCell"))
                {
                    FieldCellLonpos fc = hit.collider.GetComponent<FieldCellLonpos>();
                    if (!fc.IsBusy())
                    {
                        count++;
                        fieldCells.Add(fc);
                    }
                }
            }
        }
        
        return count == cells.Count;
    }

    public bool Match(bool match)
    {
        if (match)
        {
            FieldController.Instance.InvokeHint();
            Vector3 minPos = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            circle.enabled = false;
            for (int i = 0; i < fieldCells.Count; i++)
            {
                fieldCells[i].ChangeBusyCell(true);

                if (Vector3.Distance(cells[i].transform.position, fieldCells[i].transform.position) < Vector3.Distance(cells[i].transform.position, minPos))
                {
                    minPos = cells[i].transform.position - fieldCells[i].transform.position;
                }
            }
            ResetLerp();
            targetPosition = transform.position - minPos;
            targetPosition.z = -0.5f;
            onField = true;
            magnet.Play();
            FieldController.Instance.CheckCells();
            return true;
        }
        ReturnFigurePosition();
        return false;
    }

    private void ReturnFigurePosition()
    {
        GetComponent<Collider2D>().enabled = true;
        ResetLerp();
        targetPosition = startPosition;
        transform.localScale = new Vector3(0.5f, 0.5f, 1);
    }

    public void PingPong()
    {
        baseColor = cells[0].GetComponentInChildren<SpriteRenderer>().color;
        dark = true;
    }
    float darkPong = 0.8f;
    float darkMulty = 0.3f;
    float darkPlus = 0.1f;

    private void Update()
    {
        if (dark)
        {
            for (int j = 0; j < cells.Count; j++)
            {
                SpriteRenderer hintRenderer = cells[j].GetComponentInChildren<SpriteRenderer>();
                float emission = 1/Mathf.PingPong(Time.time, darkPong); //Mathf.PingPong (Time.time, 1.0f);

                Color finalColor = baseColor * (Mathf.LinearToGammaSpace(emission) * darkMulty + darkPlus);
                hintRenderer.color = finalColor;
            }
        }
        positionTimer += Time.deltaTime;
        transform.position = Vector3.Lerp(pastPosition, targetPosition, positionTimer / positionDelay);
    }

    public void ChangeSkin(int number)
    {
        for (int i = 0; i < cellSkins.Length; i++)
        {
            cellSkins[i].ChangeSkin(number);
        }
    }
}
