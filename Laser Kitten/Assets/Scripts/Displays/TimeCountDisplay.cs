using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeCountDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float time = GameObject.Find("EventSystem").GetComponent<StatisticsTracker>().totalTime;
        GetComponent<TextMeshProUGUI>().SetText(Mathf.FloorToInt(time / 60) + ":" + Mathf.FloorToInt((time % 60) / 10) + Mathf.FloorToInt((time % 60) % 10));
    }
}
