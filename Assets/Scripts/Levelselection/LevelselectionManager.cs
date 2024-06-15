using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelselectionManager : MonoBehaviour
{
    public GameObject pause;
    public GameObject transitionstart;
    public GameObject transitionend;

    private void Start()
    {
        GameObject t = Instantiate(transitionend);
        Destroy(t, 2.5f);
        pause.SetActive(false);
        Time.timeScale = 1; 
    }
    public void Update()
    {
        //to let players pause the game

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.E))
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
}
