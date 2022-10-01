using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

[RequireComponent(typeof(ScrollRect))]
public class ScrollController : MonoBehaviour
{
    public float scrollSpeed = 10f;

    int maxlvl = 81;
    ScrollRect m_ScrollRect;
    RectTransform m_RectTransform;
    RectTransform m_ContentRectTransform;
    RectTransform m_SelectedRectTransform;

    [SerializeField] public GameObject target;

    private void Start()
    {
        UpdateTarget();
    }
    public void UpdateTarget()
    {
        scrollSpeed = 2;
        if(PlayerPrefs.HasKey("levelsComplete"))
            if (PlayerPrefs.GetInt("levelsComplete") > 4)
            {
                UI.Instance.touchBlock.gameObject.SetActive(true);
            }
            else
                UI.Instance.touchBlock.gameObject.SetActive(false);
        else
            UI.Instance.touchBlock.gameObject.SetActive(false);

        m_ScrollRect = GetComponent<ScrollRect>();
        m_RectTransform = GetComponent<RectTransform>();
        m_ContentRectTransform = m_ScrollRect.content;

        if (PlayerPrefs.GetInt("levelsComplete") + 5 <= maxlvl)
            target = GameObject.Find((PlayerPrefs.GetInt("levelsComplete") + 5).ToString()).gameObject;
        else
            target = GameObject.Find((maxlvl + 1).ToString()).gameObject;
    }

    void Update()
    {
        UpdateScrollToSelected();
    }

    public IEnumerator enumerator()
    {
        while (true)
        {
            yield return new WaitUntil(() => true);
        }
    }

    void UpdateScrollToSelected()
    {

        // grab the current selected from the eventsystem
        GameObject selected = target;//EventSystem.current.currentSelectedGameObject;

        
        if (selected == null)
        {            
            return;
        }
        if (selected.transform.parent != m_ContentRectTransform.transform)
        {            
            return;
        }
        
               
        m_SelectedRectTransform = selected.GetComponent<RectTransform>();

        // math stuff
        Vector3 selectedDifference = m_RectTransform.localPosition - m_SelectedRectTransform.localPosition;
        float contentHeightDifference = (m_ContentRectTransform.rect.height - m_RectTransform.rect.height);

        float selectedPosition = (m_ContentRectTransform.rect.height - selectedDifference.y);
        float currentScrollRectPosition = m_ScrollRect.normalizedPosition.y * contentHeightDifference;
        float above = currentScrollRectPosition - (m_SelectedRectTransform.rect.height / 2) + m_RectTransform.rect.height;
        float below = currentScrollRectPosition + (m_SelectedRectTransform.rect.height / 2);        

        // check if selected is out of bounds
        if (selectedPosition >= above)
        {
            float step = selectedPosition - above;
            float newY = currentScrollRectPosition + step; // временное исправление
            float newNormalizedY = newY / contentHeightDifference;
            m_ScrollRect.normalizedPosition = Vector2.Lerp(m_ScrollRect.normalizedPosition, new Vector2(0, newNormalizedY), scrollSpeed * Time.deltaTime);

            if(step <= 50)
            {
                UI.Instance.touchBlock.gameObject.SetActive(false);
                scrollSpeed = 0;
            }
        }
        else if (selectedPosition <= below)
        {
            float step = selectedPosition - below;
            float newY = currentScrollRectPosition + step;
            float newNormalizedY = newY / contentHeightDifference;
            m_ScrollRect.normalizedPosition = Vector2.Lerp(m_ScrollRect.normalizedPosition, new Vector2(0, newNormalizedY), scrollSpeed * Time.deltaTime);

            if (step >= 50)
            {
                UI.Instance.touchBlock.gameObject.SetActive(false);
                scrollSpeed = 0;
            }
        }        
    }
}