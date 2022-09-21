using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    private StatLogger sl;
    public bool win;
    public GameObject WinCanvas;
    public string objective;
    // Start is called before the first frame update
    void Start()
    {
        sl = GameObject.Find("Logger").GetComponent<StatLogger>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (objective)
        {
            case "YARN":
                DoYarn();
                break;
            case "TIME":
                DoTime();
                break;
        }
    }

    void Win()
    {
        if (win)
        {
            if (Time.deltaTime != 0) sl.LogAttempts();
            SaveLvlProgress();
            SaveStatistics();
            WinCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }
    void DoYarn()
    {
        // define an array of yarnballs
        GameObject[] yarnballs = GameObject.FindGameObjectsWithTag("Yarn");

        if (yarnballs.Length == 0)
        {
            win = true;
            Win();
            if (GameObject.Find("UI Info") != null)
                GameObject.Find("UI Info").SetActive(false);
        }
        else
        {
            win = false;
        }
    }
    void DoTime()
    {

    }
    void SaveLvlProgress()
    {
        // if you win and lvlProgress < levelNumber
        if (win && GameObject.Find("ProgressData").GetComponent<ProgressData>().lvlProgress < gameObject.GetComponent<SceneControl>().levelNumber)
        {
            // lvlProgress will always be the number of the level you most recently beat
            GameObject.Find("ProgressData").GetComponent<ProgressData>().lvlProgress = gameObject.GetComponent<SceneControl>().levelNumber;
            PlayerPrefs.SetInt("lvlProgress", GameObject.Find("ProgressData").GetComponent<ProgressData>().lvlProgress);
        }
    }
    void SaveStatistics()
    {
        for (int i = 0; i < sl.currentAttempts.Length; i++)
        {
            PlayerPrefs.SetInt("currentAttempts[" + i + "]", sl.currentAttempts[i]);
            PlayerPrefs.SetInt("bestAttempts[" + i + "]", sl.bestAttempts[i]);
            PlayerPrefs.SetInt("bestTaps[" + i + "]", sl.bestTaps[i]);
            PlayerPrefs.SetFloat("bestTime[" + i + "]", sl.bestTime[i]);
        }
    }
}
