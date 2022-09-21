using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatLogger : MonoBehaviour
{
    private StatisticsTracker st;
    private Objective obj;

    private int lvlNum;

    public int[] bestAttempts;
    public int[] bestTaps;
    public float[] bestTime;

    public int[] currentAttempts;

    // Start is called before the first frame update
    void Awake()
    {
        // grab stats
        for (int i = 0; i < currentAttempts.Length; i++)
        {
            if (PlayerPrefs.HasKey("currentAttempts[" + i + "]"))
                currentAttempts[i] = PlayerPrefs.GetInt("currentAttempts[" + i + "]");
            if (PlayerPrefs.HasKey("bestAttempts[" + i + "]"))
                bestAttempts[i] = PlayerPrefs.GetInt("bestAttempts[" + i + "]");
            if (PlayerPrefs.HasKey("bestTaps[" + i + "]"))
                bestTaps[i] = PlayerPrefs.GetInt("bestTaps[" + i + "]");
            if (PlayerPrefs.HasKey("bestTime[" + i + "]"))
                bestTime[i] = PlayerPrefs.GetFloat("bestTime[" + i + "]");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("EventSystem") != null)
        {
            lvlNum = GameObject.Find("EventSystem").GetComponent<SceneControl>().levelNumber - 1;
            st = GameObject.Find("EventSystem").GetComponent<StatisticsTracker>();
            obj = GameObject.Find("EventSystem").GetComponent<Objective>();
            LogTaps();
            LogTime();
        }
    }

    // THIS IS CALLED IN OBJECTIVE SCRIPT WHEN THE PLAYER WINS
    public void LogAttempts()
    {
        //Debug.Log("current: " + currentAttempts[lvlNum] + " best: " + bestAttempts[lvlNum]);
        if (currentAttempts[lvlNum] < bestAttempts[lvlNum] || bestAttempts[lvlNum] == 0)
        {
            bestAttempts[lvlNum] = currentAttempts[lvlNum];
        }
    }
    void LogTaps()
    {
        // test if player wins the level and sets a record for the least number of taps
        if (obj.win && (st.totalTaps < bestTaps[lvlNum] || bestTaps[lvlNum] == 0))
        {
            bestTaps[lvlNum] = st.totalTaps;
        }
    }
    void LogTime()
    {
        if (obj.win && (st.totalTime < bestTime[lvlNum] || bestTime[lvlNum] == 0))
        {
            bestTime[lvlNum] = st.totalTime;
        }
    }
}
