using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float timeInSplash = 7.0f;

    private string currentSceneName;
    private static int currentbuildIndex;
    private bool isPaused;

    private void Awake()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        currentbuildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Start()
    {               
        if (currentSceneName == "00_Splash" ) {
            StartCoroutine(Splash());
        }
    }

    IEnumerator Splash()
    {
        // One way to add a delay
        yield return new WaitForSeconds(timeInSplash);
        LoadNextLevel();
    }

    public static int GetBuildIndex()
    {
        return currentbuildIndex;
    }

    public void LoadLevel(string name)
    {
        if (name == "Level_01")
        {
            // TODO is this the right place?
            //ScoreKeeper.score = 0;
            //Lives.lives = 3;
        }

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

        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
        }
    }

}
