using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField] private HealthDisplay healthDisplay;
    [SerializeField] private int life = 3;

    public static GameManager instance;

    private void Awake()
    {
        var numGameManager = FindObjectsOfType<GameManager>().Length;

        if (numGameManager > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            healthDisplay.LifeUpdate(life);
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadLevel(int LevelIndex)
    {
        SceneManager.LoadScene(LevelIndex);
        DOTween.KillAll();
    }

    public void LoadMenu()
    {
        LoadLevel(0);
        Destroy(gameObject);
    }

    public void LoadNextLevel()
    {
        int nextSceneBuildIndex = GetCurrentSceneIndex() + 1;

        if (nextSceneBuildIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneBuildIndex = 0;

        }

        LoadLevel(nextSceneBuildIndex);
        DOTween.KillAll();
    }

    public void ProcessPlayerDeath()
    {
        life--;

        healthDisplay.LifeUpdate(life);
        if (life == 0)
        {
            LoadMenu();
        }
        else
        {
            LoadLevel(GetCurrentSceneIndex());
        }
    }

    private int GetCurrentSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
