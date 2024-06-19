using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressurePlateManager : MonoBehaviour
{
    [SerializeField] GameObject Door;
    [SerializeField] Button button;


    public bool Plate1;
    public bool Plate2;

    private void Update()
    {
        if(Plate1 == true && Plate2 == true)
        {
            Door.SetActive(false);
            button.gameObject.SetActive(true);
        } 
    }

}
