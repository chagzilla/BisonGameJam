using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Quitgame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
    public void Startgame()
    {
        //To start the game with no level beaten

        StartCoroutine(LoadLevelSelection());
    }
    public void Continuegame()
    {
        //To start the game where last left off

        StartCoroutine(LoadLevelSelection());
    }

    private IEnumerator LoadLevelSelection()
    {

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Level Selection");
    }
}
