using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.7f;

    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultDifficulty = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // - When you go to the "options screen" from your start menu, this line will
        // - 1) fetch(abholen) the value for the volume which is currently saved in your "PlayerPrefsController" script
        // - 2) set the value "value" of your slider to that saved volume.
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();

        difficultySlider.value = PlayerPrefsController.GetDifficulty();

    }

    // Update is called once per frame
    void Update()
    {
        // Gonna be accessing the MusicPlayer
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No MusicPlayer found...did you start from splash screen");
        }
    }
    
    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty(difficultySlider.value);

        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }

    public void SetDefault()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;

    }
}
