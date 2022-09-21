using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().SetText("Level " + GameObject.Find("EventSystem").GetComponent<SceneControl>().levelNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
