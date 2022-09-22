using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void LoadCurrentLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void LoadNextLevel()
    {
        int nextSceneBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneBuildIndex == SceneManager.sceneCountInBuildSettings)
        {
            LoadCurrentLevel(0);

        }
        else
        {
            SceneManager.LoadScene(nextSceneBuildIndex);
        }
    }

    public void ProcessPlayerDeath()
    {
        SceneManager.LoadScene(GetCurrentSceneIndex());
    }

    private int GetCurrentSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
