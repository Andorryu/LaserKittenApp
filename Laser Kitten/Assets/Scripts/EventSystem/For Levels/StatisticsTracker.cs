using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatisticsTracker : MonoBehaviour
{
    public GameObject logger;
    public StatLogger sl;
    public int totalYarn;
    public int totalTaps;
    public float totalTime;
    private int lvlNum;

    // Start is called before the first frame update
    void Start()
    {
        logger = GameObject.Find("Logger");
        sl = logger.GetComponent<StatLogger>();
        lvlNum = GetComponent<SceneControl>().levelNumber - 1;

        totalYarn = GameObject.FindGameObjectsWithTag("Yarn").Length;
        totalTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CountTaps();

        if (GetComponent<Objective>().win)
        {
            GameObject.FindGameObjectWithTag("Total Yarn").GetComponent<TextMeshProUGUI>().SetText(GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>().collectedYarn + "/" + totalYarn);
            GameObject.FindGameObjectWithTag("Total Taps").GetComponent<TextMeshProUGUI>().SetText(totalTaps.ToString());
            GameObject.FindGameObjectWithTag("Total Time").GetComponent<TextMeshProUGUI>().SetText(Mathf.FloorToInt(totalTime / 60) + ":" + Mathf.FloorToInt((totalTime % 60) / 10) + Mathf.FloorToInt((totalTime % 60) % 10));
            GameObject.FindGameObjectWithTag("Total Attempts").GetComponent<TextMeshProUGUI>().SetText(sl.bestAttempts[lvlNum].ToString());
        }
    }
    private void FixedUpdate()
    {
        CountTime();
    }

    void CountTaps()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().enabled)
        {
            if (Input.GetMouseButtonDown(0) && !GetComponent<PauseManager>().hoverOverMouse && !GetComponent<Objective>().win)
            {
                totalTaps++;
            }
        }
    }
    void CountTime()
    {
        if (GameObject.FindGameObjectWithTag("Fade") == null)
        {
            totalTime += Time.deltaTime;
        }
    }

    // THIS IS CALLED IN THE DAMAGER SCRIPT WHEN THE PLAYER HITS A WALL
    public void CountAttempts()
    {
        if (GameObject.Find("Logger") != null)
            GameObject.Find("Logger").GetComponent<StatLogger>().currentAttempts[lvlNum]++;
    }
}
