using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioToggler : MonoBehaviour
{
    public bool isOn;

    [SerializeField] Button soundButton;
    [SerializeField] Sprite soundEnabledSprite;
    [SerializeField] Sprite soundDisabledSprite;

    private void Start()
    {
        if(PlayerPrefs.HasKey("SoundEnabled"))
        {
            isOn = true;
            soundButton.image.sprite = soundEnabledSprite;
        }

        if(PlayerPrefs.HasKey("SoundDisabled"))
        {
            isOn = false;
            soundButton.image.sprite = soundDisabledSprite;
        }
    }

    public void OnOffSound()
    {
        if(!isOn)
        {
            AudioListener.volume = 1f;
            isOn = true; 
            PlayerPrefs.SetString("SoundEnabled", "enabled");
            PlayerPrefs.DeleteKey("SoundDisabled");
            soundButton.image.sprite = soundEnabledSprite;

        }
        else if (isOn)
        {
            AudioListener.volume = 0f;
            isOn = false;
            PlayerPrefs.SetString("SoundDisabled", "disabled");
            PlayerPrefs.DeleteKey("SoundEnabled");
            soundButton.image.sprite = soundDisabledSprite;

        }
    }

    
}
