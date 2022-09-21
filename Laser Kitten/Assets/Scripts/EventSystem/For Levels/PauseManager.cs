using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool paused;
    public bool hoverOverMouse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (pauseMenu.activeSelf && pauseMenu != null)
        {
            paused = true;
        }

        // when mouse is inside bounds of pause button
        if (GameObject.Find("Pause Button") != null)
            hoverOverMouse = Input.mousePosition.x >= (GameObject.Find("Pause Button").GetComponent<RectTransform>().position.x - (GameObject.Find("Pause Button").GetComponent<RectTransform>().sizeDelta.x / 2))
                && Input.mousePosition.x <= (GameObject.Find("Pause Button").GetComponent<RectTransform>().position.x + (GameObject.Find("Pause Button").GetComponent<RectTransform>().sizeDelta.x / 2))
                && Input.mousePosition.y >= (GameObject.Find("Pause Button").GetComponent<RectTransform>().position.y - (GameObject.Find("Pause Button").GetComponent<RectTransform>().sizeDelta.y / 2))
                && Input.mousePosition.y <= (GameObject.Find("Pause Button").GetComponent<RectTransform>().position.y + (GameObject.Find("Pause Button").GetComponent<RectTransform>().sizeDelta.y / 2));
    }

    public void Pause(bool pause)
    {
        if (pause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().enabled = !pause;
        pauseMenu.SetActive(pause);
    }
}
