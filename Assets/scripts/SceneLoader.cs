using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ChangeMainGameScene()
    {
        SceneManager.LoadScene("main-game");
    }

    public void ChangeMainMenuScene()
    {
        SceneManager.LoadScene("main-menu");
    }


    public void ChangeCreditsScene()
    {
        SceneManager.LoadScene("credits");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
