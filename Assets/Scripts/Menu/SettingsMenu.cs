using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    [SerializeField] public TMP_Dropdown resolutionDropdown;
    [SerializeField] public TMP_Dropdown FullscreenDropdown;

    //Resolutions manual list 
    private List<Vector2Int> predefinedResolutions = new List<Vector2Int>
     {
         new Vector2Int(1024, 768),
         new Vector2Int(1280, 720),
         new Vector2Int(1920, 1080),
     };
    private void Start()
     {
         //Create dropdown options list
         List<string> options = new List<string>();
         int currentResolutionIndex = 0;

         for (int i = 0; i < predefinedResolutions.Count; i++)
         {
             string option = predefinedResolutions[i].x + " x " + predefinedResolutions[i].y;
             options.Add(option);

             // Checking current screen resolution
              if (predefinedResolutions[i].x == Screen.width &&
                 predefinedResolutions[i].y == Screen.height)
             {
                 currentResolutionIndex = i;
             }
         }
         // Adding options to dropdown
         resolutionDropdown.ClearOptions();
         resolutionDropdown.AddOptions(options);
         
         // Set the default dropdown value to the current resolution
         resolutionDropdown.value = currentResolutionIndex;
         resolutionDropdown.RefreshShownValue();
         
        // Add listener to change value in dropdown
         resolutionDropdown.onValueChanged.AddListener(delegate { 
             SetResolution(resolutionDropdown.value);
         });
     }

     public void SetResolution(int resolutionIndex)
     {
         Vector2Int selectedResolution = predefinedResolutions[resolutionIndex];
         Screen.SetResolution(selectedResolution.x, selectedResolution.y, Screen.fullScreen);
         Debug.Log("workinggg");
     }

     public void SetVolume(float volume)
    {
        //Connect slider with mixer
        audioMixer.SetFloat("Volume", volume);
    }
     public void FullScreen()
    {
        //Changed dropbox value 1,2,3... to text added to this dropbox
        int pickedEntryIndex = FullscreenDropdown.value;
        string selectedOption = FullscreenDropdown.options[pickedEntryIndex].text;

        //Checking is fullscreen selected or windowed 
        if (selectedOption == "FullScreen") 
        {
            Screen.fullScreen = true;
        }else 
        {
            Screen.fullScreen = false;
        }
    }
}
