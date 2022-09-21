using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttemptsDisplay : MonoBehaviour
{
    public TextMeshProUGUI text;
    private int lvlNum;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        lvlNum = GameObject.Find("EventSystem").GetComponent<SceneControl>().levelNumber - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Logger") != null)
            text.text = "Attempt " + GameObject.Find("Logger").GetComponent<StatLogger>().currentAttempts[lvlNum];
    }
}
