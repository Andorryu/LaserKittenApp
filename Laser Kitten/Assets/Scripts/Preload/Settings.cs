using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public bool displayStatsInGame;
    public bool animateLaser;

    public float musicVolume;
    public float soundEffectVolume;

    // Start is called before the first frame update
    void Awake()
    {
        // load saved settings
        if (PlayerPrefs.HasKey("displayStatsInGame"))
            displayStatsInGame = Tools.IntToBool(PlayerPrefs.GetInt("displayStatsInGame"));
        if (PlayerPrefs.HasKey("animateLaser"))
            animateLaser = Tools.IntToBool(PlayerPrefs.GetInt("animateLaser"));
        if (PlayerPrefs.HasKey("musicVolume"))
            musicVolume = PlayerPrefs.GetFloat("musicVolume");
        if (PlayerPrefs.HasKey("soundEffectVolume"))
            soundEffectVolume = PlayerPrefs.GetFloat("soundEffectVolume");
    }

    // Update is called once per frame
    void Update()
    {
        // change displayStatsInGame
        if (GameObject.Find("Stats Display") != null)
            GameObject.Find("Stats Display").SetActive(displayStatsInGame);

        // change animateLaser
        if (GameObject.Find("EventSystem") != null)
            GameObject.Find("EventSystem").GetComponent<MoveLaser>().animateLaser = animateLaser;

        // change music volume
        if (GameObject.Find("Theme") != null)
            GameObject.Find("Theme").GetComponent<AudioSource>().volume = musicVolume;

        // change sound effect volume
        if (GameObject.FindGameObjectWithTag("Laser") != null)
        {
            foreach (AudioSource sound in GameObject.FindGameObjectWithTag("Laser").GetComponents<AudioSource>())
            {
                sound.volume = soundEffectVolume;
            }
        }
    }
}
