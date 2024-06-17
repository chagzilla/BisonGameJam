using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelselectionManager : MonoBehaviour
{
    public GameObject pause;
    public GameObject transitionstart;
    public GameObject transitionend;
    public GameObject[] LevelsS;
    public Transform bison;
    private bool left;

    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "Level Selection")
        {
            bison.position = new Vector3(PlayerPrefs.GetFloat("LSPosition"), 0, 0);
        }
        GameObject t = Instantiate(transitionend);
        Destroy(t, 2.5f);
        pause.SetActive(false);
        Time.timeScale = 1;
        left = true;
    }
    public void Update()
    {
        //to let players pause the game

        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.E))&& left == true)
        {
            if(pause.activeSelf)
            {
                pause.SetActive(false);
                Time.timeScale = 1;
            }
            else if (!pause.activeSelf) 
            {
                pause.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void returnmainmenu()
    {
        PlayerPrefs.SetFloat("LSPosition", bison.position.x);
        left = false;
        foreach (GameObject t in LevelsS)
        {
            Destroy(t);
        }
        Time.timeScale = 1;
        StartCoroutine(LoadMainmenu());
    }

    public IEnumerator LoadMainmenu()
    {
        GameObject t = Instantiate(transitionstart);
        Destroy(t, 2.5f);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Main Menu");
    }

    public void Quitgame()
    {
        PlayerPrefs.SetFloat("LSPosition", bison.position.x);
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void BackLevelSelection()
    {
        SceneManager.LoadScene("Level Selection");
    }
}
