using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrefsTest : MonoBehaviour
{
    float time = 0;
    void Update()
    {
        if (Input.touchCount >= 5)
        {
            time += Time.deltaTime;
            if (time > 3)
            {
                UnlockAll();
            }
        }
        if (Input.touchCount == 4)
        {
            time += Time.deltaTime;
            if (time > 3)
            {
                ResetAll();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("levelsComplete", 3);
            PlayerPrefs.SetInt("level1", 3);
            PlayerPrefs.SetInt("level2", 2);
            PlayerPrefs.SetInt("level3", 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UnlockAll();
        }
    }

    void ResetAll()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(Settings.LEVELS_SCENE);
    }
    void UnlockAll()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("levelsComplete", 81);
        for (int i = 1; i < 81; i++)
        {
            PlayerPrefs.SetInt("level" + i.ToString(), 2);
        }
        SceneManager.LoadScene(Settings.LEVELS_SCENE);
    }
}
