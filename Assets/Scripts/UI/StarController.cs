using System.Collections;
using System;
using UnityEngine;

public class StarController : MonoBehaviour
{
    SpriteRenderer[] stars;

    private bool isPassed = false;
    private void Awake()
    {
        stars = transform.GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].gameObject.SetActive(false);
        }
        Complete(true);
    }

    public void Complete(bool instant = false)
    {
        if (PlayerPrefs.HasKey("LastPassedLevel"))
        {
            if (PlayerPrefs.GetString("LastPassedLevel") == name)
            {
                isPassed = true;
                if (instant)
                {
                    for (int i = 0; i < stars.Length; i++)
                    {
                        stars[i].gameObject.SetActive(true);
                    }
                }
                else
                {
                    StartCoroutine(StarProgress());
                }
                PlayerPrefs.DeleteKey("LastPassedLevel");
            }
        }
        if (PlayerPrefs.HasKey("levelsComplete") && !isPassed)
        {
            int index = 0;
            string numLevel = string.Empty;
            while (char.IsDigit(name[index]))
            {
                numLevel += name[index];
                index++;
            }
            int level = Convert.ToInt32(numLevel);

            if (PlayerPrefs.GetInt("levelsComplete") >= level)
            {
                for (int i = 0; i < stars.Length; i++)
                    stars[i].gameObject.SetActive(true);
            }
        }
    }

    private IEnumerator StarProgress()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].gameObject.SetActive(true);
            UI.Instance.PlayStarSound();
            yield return new WaitForSeconds(0.3f);
        }
    }
}
