using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Sound : MonoBehaviour
{
    public Slider volumeSd;
    public Slider buttonVolSd;
    public AudioSource audio;
    public AudioSource buttonAudioY;
    public AudioSource buttonAudioN;
    private float baseVol;
    private float buttonBaseVol;

    public GameObject settingPanel;
    public GameObject canvas;
    private Button[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        buttonBaseVol = PlayerPrefs.GetFloat("buttonBaseVol",0.5f);
        buttonVolSd.value = buttonBaseVol;
        buttonAudioY.volume = buttonVolSd.value;
        buttonAudioN.volume = buttonVolSd.value;


        baseVol = PlayerPrefs.GetFloat("baseVol", 0.5f);
        volumeSd.value = baseVol;
        audio.volume = volumeSd.value;


        

    }

    // Update is called once per frame
    void Update()
    {
        audio.volume = volumeSd.value;

        baseVol = volumeSd.value;
        PlayerPrefs.SetFloat("baseVol", baseVol);

        buttonAudioY.volume = buttonVolSd.value;
        buttonAudioN.volume = buttonVolSd.value;
        buttonBaseVol = buttonVolSd.value;
        PlayerPrefs.SetFloat("buttonBaseVol", buttonBaseVol);
    }

   


    public void SettingOnOff()
    {
        if (settingPanel.activeSelf)
        {
            settingPanel.SetActive(false);
        }
        else
        {
            settingPanel.SetActive(true);
        }
    }

    
}
