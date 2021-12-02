using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneYukleme : MonoBehaviour
{
    public void StartTheGame()
    {
        SceneManager.LoadScene(1);
    }

    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
