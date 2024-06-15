using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelselectionManager : MonoBehaviour
{
    public GameObject pause;

    private void Start()
    {
        pause.SetActive(false);
        Time.timeScale = 1; 
    }
    public void Update()
    {
        //to let players pause the game

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.E))
        {
            print("jo0");
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
        Time.timeScale = 1;
        StartCoroutine(LoadMainmenu());
    }

    public IEnumerator LoadMainmenu()
    {

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Main Menu");
    }
}
