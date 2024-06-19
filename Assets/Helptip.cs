using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helptip : MonoBehaviour
{
    [SerializeField] private Button button;
    

    private void OnTriggerEnter2D(Collider2D c){
        button.gameObject.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D c){
        if (c.tag == "Player")
        {
            if (button != null)
            {
                button.gameObject.SetActive(false);
            }
        }
    }
}
 