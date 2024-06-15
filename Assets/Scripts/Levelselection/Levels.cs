using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    public GameObject Icon;
    private bool insidecollider;
    void Start()
    {
        Icon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))&&insidecollider)
        {
            //Start a level
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
        Icon.SetActive(false);
    }
}
