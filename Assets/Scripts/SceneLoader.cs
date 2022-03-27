using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    public static void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public static void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }
    public static void LoadMissionFailed()
    {
        SceneManager.LoadScene(11);
    }
}
