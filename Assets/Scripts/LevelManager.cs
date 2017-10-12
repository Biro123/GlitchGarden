using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {

    public float timeInSplash = 7.0f;

    private string currentSceneName;
    private static int currentbuildIndex;
    private GameObject startPanel;

    private void Awake()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        currentbuildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Start()
    {   
        if (currentSceneName.Substring(0, 2) == "02")
        {
            PlayerPrefsManager.SetCurrentLevel(currentSceneName);
        }

        if (currentSceneName == "00_Splash" ) {
            StartCoroutine(Splash());
        }
        else
        {
            FindStartPanel();
            if (startPanel)
            {
                PausePressed();
            }
        }
    }

    IEnumerator Splash()
    {
        // One way to add a delay
        yield return new WaitForSeconds(timeInSplash);
        LoadNextLevel();
    }

    private void FindStartPanel()
    {
        startPanel = GameObject.Find("StartPanel");

        if (!startPanel)
        {
            Debug.LogWarning("StartPanel is missing");
        }
    }


    public static int GetBuildIndex()
    {
        return currentbuildIndex;
    }

    public void Replay()
    {
        string lastLevel = PlayerPrefsManager.getCurrentLevel();

        if (lastLevel.Substring(0, 2) == "02")
        {
            LoadLevel(lastLevel);
        }
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit Requested");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
         /// buildindex is from build settings.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        throw new System.NotImplementedException();
    }

    public void PausePressed()
    {
        Time.timeScale = 0;
        startPanel.SetActive(true);
    }

    public void PlayPressed()
    {
        Time.timeScale = 1;
        FindStartPanel(); // not sure why I have to re-find - but won't work otherwise.
        startPanel.SetActive(false);
    }

}
