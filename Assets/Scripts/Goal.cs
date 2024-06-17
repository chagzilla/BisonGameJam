using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public bool Farm;
    public bool Forest;
    public bool Desert;
    public bool City;
    public bool Tundra;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(Farm)
            {
                PlayerPrefs.SetInt("Farm", 1);
            }
            if (Forest)
            {
                PlayerPrefs.SetInt("Forest", 1);
            }
            if (Desert)
            {
                PlayerPrefs.SetInt("Desert", 1);
            }
            if (City)
            {
                PlayerPrefs.SetInt("City", 1);
            }
            if (Tundra)
            {
                PlayerPrefs.SetInt("Tundra", 1);
            }
            SceneManager.LoadScene("Level Selection");
        }
    }


}
