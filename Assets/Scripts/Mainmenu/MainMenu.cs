using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject transitionend;
    public GameObject transitionstart;
    private void Start()
    {
        //Make a fade-in where an object (canvas with image) is instantiated and slowly dissapears
        GameObject t = Instantiate(transitionend);
        Destroy(t, 2.5f);
    }
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
        //Transition to the levelselection

        GameObject t = Instantiate(transitionstart);
        Destroy(t, 2.5f);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Level Selection");
    }
}
