using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class StarController : MonoBehaviour
{
    SpriteRenderer[] stars;

    public bool isPassed = false;

    float time = .25f;
    float currentTime = 0;
    int numberStar = 0;
    private void Awake()
    {
        stars = transform.GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].gameObject.SetActive(false);
        }
        Complete();
    }

    public void Complete()
    {
        if (PlayerPrefs.HasKey("LastPassedLevel"))
        {
            if (PlayerPrefs.GetString("LastPassedLevel") == name)
            {
                isPassed = true;
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

    private void Update()
    {
        if (isPassed)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= time)
            {
                if (numberStar >= stars.Length)
                {
                    return;
                }

                stars[numberStar].gameObject.SetActive(true);
                //stars[numberStar].GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("sounds");
                //stars[numberStar].GetComponent<AudioSource>().Play();

                numberStar += 1;
                currentTime = 0;
            }
        }
    }
}
