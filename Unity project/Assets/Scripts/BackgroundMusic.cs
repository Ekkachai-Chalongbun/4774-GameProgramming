using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Update()
    {
        var audioSource = instance.GetComponent<AudioSource>();

        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            audioSource.Pause();
        }

        if (SceneManager.GetActiveScene().name == "Scene1")
        {
            audioSource.UnPause();
        }
    }
}
