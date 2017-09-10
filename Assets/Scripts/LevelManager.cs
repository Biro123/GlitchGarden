using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float timeInSplash = 7.0f;

    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "00_Splash" ) {
            StartCoroutine(Splash());
        }
    }

    IEnumerator Splash()
    {
        print("Before wait:" + Time.time);
        yield return new WaitForSeconds(timeInSplash);
        print("After wait:" + Time.time);
        LoadNextLevel();
    }

    public void LoadLevel(string name)
    {
        if (name == "Level_01")
        {
            // TODO is this the right place?
            ScoreKeeper.score = 0;
            Lives.lives = 3;
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
}
