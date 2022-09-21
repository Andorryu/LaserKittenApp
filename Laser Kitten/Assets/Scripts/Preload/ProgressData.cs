using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressData : MonoBehaviour
{
    public int lvlProgress;
    public GameObject[] buttons1;
    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerPrefs.HasKey("lvlProgress"))
        lvlProgress = PlayerPrefs.GetInt("lvlProgress");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Set1") != null) DisableLvlButtons();
    }
    void DisableLvlButtons()
    {
        for (int i = 0; i <= 15; i++)
        {
            buttons1[i] = GameObject.Find("Set1").transform.GetChild(i).gameObject;
        }
        // set disabled buttons on LevelSelect
        foreach (GameObject button in buttons1)
        {
            bool interactable;
            if (System.Convert.ToInt32(button.name) < lvlProgress + 2)
                interactable = true;
            else
                interactable = false;
            button.GetComponent<Button>().interactable = interactable;
        }
    }
}
