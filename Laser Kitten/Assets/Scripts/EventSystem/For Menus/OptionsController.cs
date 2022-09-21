using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsController : MonoBehaviour
{
    private StatLogger sl;
    private ProgressData pd;

    private Settings settings;

    private Toggle toggle1;
    private Toggle toggle2;

    private Slider musicVolumeSlider;
    private Slider soundEffectSlider;

    // Start is called before the first frame update
    void Start()
    {
        // references
        sl = GameObject.Find("Logger").GetComponent<StatLogger>();
        pd = GameObject.Find("ProgressData").GetComponent<ProgressData>();
        settings = GameObject.Find("Settings Holder").GetComponent<Settings>();

        // for display stats in game
        toggle1 = GameObject.Find("Toggle1").GetComponent<Toggle>();
        // for animate laser
        toggle2 = GameObject.Find("Toggle2").GetComponent<Toggle>();
        // for music slider
        musicVolumeSlider = GameObject.Find("MusicVolumeSlider").GetComponent<Slider>();
        // for sound effect slider
        soundEffectSlider = GameObject.Find("SoundEffectVolumeSlider").GetComponent<Slider>();


        // update options screen with whatever the saved value is
        toggle1.isOn = settings.displayStatsInGame;
        toggle2.isOn = settings.animateLaser;

        musicVolumeSlider.value = settings.musicVolume;
        soundEffectSlider.value = settings.soundEffectVolume;
    }

    // Update is called once per frame
    void Update()
    {
        // update the saved value with whatever the option is for preload and playerprefs
        settings.displayStatsInGame = toggle1.isOn;
        settings.animateLaser = toggle2.isOn;
        PlayerPrefs.SetInt("displayStatsInGame", Tools.BoolToInt(toggle1.isOn));
        PlayerPrefs.SetInt("animateLaser", Tools.BoolToInt(toggle2.isOn));

        // set music volume
        settings.musicVolume = musicVolumeSlider.value;
        PlayerPrefs.SetFloat("musicVolume", musicVolumeSlider.value);

        // set sound effect volume in preload settings script
        settings.soundEffectVolume = soundEffectSlider.value;
        PlayerPrefs.SetFloat("soundEffectVolume", soundEffectSlider.value);
    }
    public void ResetStatistics()
    {
        // reset all stats from StatLogger
        for (int i = 0; i < sl.currentAttempts.Length; i++)
        {
            sl.currentAttempts[i] = 1;
            sl.bestAttempts[i] = 0;
            sl.bestTaps[i] = 0;
            sl.bestTime[i] = 0;

            PlayerPrefs.SetInt("currentAttempts[" + i + "]", 1);
            PlayerPrefs.SetInt("bestAttempts[" + i + "]", 0);
            PlayerPrefs.SetInt("bestTaps[" + i + "]", 0);
            PlayerPrefs.SetFloat("bestTime[" + i + "]", 0);
        }
    }
    public void ResetProgress()
    {
        pd.lvlProgress = 0;
        PlayerPrefs.SetInt("lvlProgress", 0);
    }
}
