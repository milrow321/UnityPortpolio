using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleManager : MonoBehaviour
{
    // Start is called before the first frame update
    

    // Update is called once per frame
    

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;


#else
        Application.Quit();
            
#endif
    }

    public void GoLoadingScene()
    {
        SceneManager.LoadScene("LoadingScene");
    }

}
