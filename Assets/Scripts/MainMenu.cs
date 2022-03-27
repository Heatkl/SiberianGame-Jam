using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void startGame()
    {
        SceneManager.LoadScene(2);
    }

    // Update is called once per frame
    public void aboutUs()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadNextScene()
    {
        SceneLoader.LoadNextScene();
    }
    public void LoadMenu()
    {
        SceneLoader.LoadMenuScene();
    }
    public void exitFunc()
    {
        Application.Quit();
    }
}
