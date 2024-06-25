using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerer : MonoBehaviour
{
    public void GameScene()
    {

        SceneManager.LoadScene("SampleScene");
    }

    public void ScoreBoardScene()
    {
        SceneManager.LoadScene("ScoreBoard");
    }

    public void MainLobbyScene()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitApplication()
    {
        
        Application.Quit();
        Debug.Log("Quit application");
    }

}
