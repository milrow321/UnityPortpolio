using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CafeManager : MonoBehaviour
{
    static public CafeManager instance;

    FurnitureManager FurnitureMg;
    CustomerManager customerMg;

    public int gold;//소지금
    public Text goldText;
    public int goldInput;//수입
    public Text goldInputText;
    public int goldOutput;//지출
    public Text goldOutputText;
    public int visitorNum;//방문손님수
    public Text visitorNumText;
    public int reputation;//평판
    public float dayTime;

    public GameObject resultUI;
    public GameObject pauseShadow;//타임스케일이 0일때 어두워지는 효과
    public GameObject settingUI;//설정창

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {

       
        gold = 100;
        goldText.text = gold.ToString();

        goldInput = 0;
        goldOutput = 0;
        resultUI.SetActive(false);
    }

    private void Update()
    {
        dayTime += Time.deltaTime;
        if (dayTime > 180f)
        {
            Time.timeScale = 0;
            resultUI.SetActive(true);
            dayTime = 0;

            goldInputText.text = goldInput.ToString();
            goldOutputText.text = goldOutput.ToString();
            visitorNumText.text = visitorNum.ToString();
        }
        goldText.text = gold.ToString();

        //if (settingUI.activeSelf) Time.timeScale = 0;
        //else if(settingUI.activeSelf) Time.timeScale = 1;

        if (Time.timeScale == 0) pauseShadow.SetActive(true);
        else pauseShadow.SetActive(false);

    }

    //수입, 지출, 방문객 수를 초기화하고 시간을 다시 재생
    public void StartNewDay()
    {
        PlayerPrefs.SetInt("gold", gold);
        goldInput = 0;
        goldOutput = 0;
        visitorNum = 0;
        Time.timeScale = 1;

        resultUI.SetActive(false);

    }

    public void ToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }

}
