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
    public GameObject wall;
    public float[] wallpos;
    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "Level Selection")
        {
            bison.position = new Vector3(PlayerPrefs.GetFloat("LSPosition"), 0, 0);

            if (PlayerPrefs.GetInt("Farm") == 0)
            {
                wall.GetComponent<Transform>().position = new Vector3(wallpos[0], 0, 0);
            }
            else if (PlayerPrefs.GetInt("Forest") == 0)
            {
                wall.GetComponent<Transform>().position = new Vector3(wallpos[1], 0, 0);
            }
            else if (PlayerPrefs.GetInt("Desert") == 0)
            {
                wall.GetComponent<Transform>().position = new Vector3(wallpos[2], 0, 0);
            }
            else if (PlayerPrefs.GetInt("City") == 0)
            {
                wall.GetComponent<Transform>().position = new Vector3(wallpos[3], 0, 0);
            }
            else if (PlayerPrefs.GetInt("Tundra") == 0)
            {
                wall.GetComponent<Transform>().position = new Vector3(wallpos[4], 0, 0);
            }
            else { Destroy(wall); }
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
