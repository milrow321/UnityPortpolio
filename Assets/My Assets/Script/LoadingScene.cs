using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public int sceneNumber=2;
    public Slider loadingBar;
    //public Text LoadingText;

    private void Start()
    {
        StartCoroutine(TransitionNextScene(sceneNumber));
    }



    IEnumerator TransitionNextScene(int num)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(num);

        ao.allowSceneActivation = false;

        while (!ao.isDone)
        {
            loadingBar.value = ao.progress;
            //LoadingText.text = (ao.progress * 100.0f).ToString() + "%";

            if (ao.progress >= 0.9f)
            {
                ao.allowSceneActivation = true;
            }

            yield return null;
        }
    }


}
