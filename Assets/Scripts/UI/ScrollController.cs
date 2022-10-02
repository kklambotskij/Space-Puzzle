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
    [SerializeField] public RectTransform m_SelectedRectTransform;

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
            m_SelectedRectTransform = GameObject.Find((PlayerPrefs.GetInt("levelsComplete") + 5).ToString()).GetComponent<RectTransform>();
        else
            m_SelectedRectTransform = GameObject.Find((maxlvl + 1).ToString()).gameObject.GetComponent<RectTransform>();
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

    [SerializeField] float selectedPosition;
    [SerializeField] float currentScrollRectPosition;
    [SerializeField] float above;
    [SerializeField] float below;

    void UpdateScrollToSelected()
    {
        if (m_SelectedRectTransform == null)
        {            
            return;
        }
        if (m_SelectedRectTransform.transform.parent != m_ContentRectTransform.transform)
        {            
            return;
        }

        // math stuff
        Vector3 selectedDifference = m_RectTransform.localPosition - m_SelectedRectTransform.localPosition;
        float contentHeightDifference = (m_ContentRectTransform.rect.height - m_RectTransform.rect.height);

        selectedPosition = m_ContentRectTransform.rect.height - selectedDifference.y;
        currentScrollRectPosition = m_ScrollRect.normalizedPosition.y * contentHeightDifference;
        above = currentScrollRectPosition - (m_SelectedRectTransform.rect.height / 2) + m_RectTransform.rect.height;

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
        else if (selectedPosition <= above)
        {
            float step = selectedPosition - above;
            float newY = currentScrollRectPosition + step;
            float newNormalizedY = newY / contentHeightDifference;
            m_ScrollRect.normalizedPosition = Vector2.Lerp(m_ScrollRect.normalizedPosition, new Vector2(0, newNormalizedY), scrollSpeed * Time.deltaTime);

            if (step <= 50)
            {
                UI.Instance.touchBlock.gameObject.SetActive(false);
                scrollSpeed = 0;
            }
        }        
    }
}