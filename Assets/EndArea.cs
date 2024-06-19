using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndArea : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button button;

    private void OnTriggerEnter2D(Collider2D c){
        Debug.Log("Detected");
        button.gameObject.SetActive(false);
    }
}
