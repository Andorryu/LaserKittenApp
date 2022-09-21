using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TapsDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().SetText(0.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().SetText(GameObject.Find("EventSystem").GetComponent<StatisticsTracker>().totalTaps + " Taps");
    }
}
