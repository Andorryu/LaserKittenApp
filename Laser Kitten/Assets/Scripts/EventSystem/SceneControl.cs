using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public int levelNumber;
    private StatLogger sl;
    private int lvlNum;

    // Start is called before the first frame update
    void Start()
    {
        sl = GameObject.Find("Logger").GetComponent<StatLogger>();
        lvlNum = levelNumber - 1;

        Time.timeScale = 1;
    }

    // public functions
    public void LoadNextScene(bool resetCountAttempts)
    {
        if (resetCountAttempts) sl.currentAttempts[lvlNum] = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadTargetScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void LoadLevelSelect(bool resetCountAttempts)
    {
        if (resetCountAttempts) sl.currentAttempts[lvlNum] = 1;
        SceneManager.LoadScene("LevelSelect");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadStatisticsMenu()
    {
        SceneManager.LoadScene("StatisticsMenu");
    }
    public void RestartScene(bool resetCountAttempts)
    {
        if (resetCountAttempts) sl.currentAttempts[lvlNum] = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("The game has successfully quit.");
    }
}
