using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkScrene : MonoBehaviour
{
    public void LoadLose()
    {
        SceneLoader.LoadMissionFailed();
    }
    public void LoadWin()
    {
        SceneLoader.LoadNextScene();
    }
}
