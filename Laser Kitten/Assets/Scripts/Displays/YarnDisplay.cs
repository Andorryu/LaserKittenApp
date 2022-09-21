using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class YarnDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // update text with number of yarn collected from YarnCollector Script
        GetComponent<TextMeshProUGUI>().SetText( GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>().collectedYarn + "/" + GameObject.Find("EventSystem").GetComponent<StatisticsTracker>().totalYarn + " Yarn Collected");
    }
}
