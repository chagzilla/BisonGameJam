using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    public GameObject Icon;
    private bool insidecollider;
    public string scenename;
    void Start()
    {
        Icon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))&&insidecollider)
        {
            if (scenename != "")
            {
                SceneManager.LoadScene(scenename);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        insidecollider = true;
        Icon.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        insidecollider = false;
        if (Icon != null)
        {
            Icon.SetActive(false);
        }
    }

}
