using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Sound : MonoBehaviour
{
    public Slider volumeSd;
    
    public AudioSource audio;
    
    private float baseVol;
    

    public GameObject settingPanel;
    

    // Start is called before the first frame update
    void Start()
    {
        


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
