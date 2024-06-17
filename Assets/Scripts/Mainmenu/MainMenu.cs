using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject transitionend;
    public GameObject transitionstart;
    public Button continuegame;
    private void Start()
    {
        if(PlayerPrefs.GetInt("Gamestarted") == 0)
        {
            continuegame.interactable = false;
        }
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
        PlayerPrefs.SetFloat("LSPosition", 0);
        PlayerPrefs.SetInt("Gamestarted", 1);
        PlayerPrefs.SetInt("Farm", 0);
        PlayerPrefs.SetInt("Forest", 0);
        PlayerPrefs.SetInt("Desert", 0);
        PlayerPrefs.SetInt("City", 0);
        PlayerPrefs.SetInt("Tundra", 0);
        StartCoroutine(LoadLevelSelection());
    }
    public void StartFullgame()
    {
        //To start the game with no level beaten
        PlayerPrefs.SetFloat("LSPosition", 0);
        PlayerPrefs.SetInt("Gamestarted", 1);
        PlayerPrefs.SetInt("Farm", 1);
        PlayerPrefs.SetInt("Forest", 1);
        PlayerPrefs.SetInt("Desert", 1);
        PlayerPrefs.SetInt("City", 1);
        PlayerPrefs.SetInt("Tundra", 1);
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
