using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateManager : MonoBehaviour
{
    [SerializeField] GameObject Door;

    public bool Plate1;
    public bool Plate2;

    private void Update()
    {
        if(Plate1 == true && Plate2 == true)
        {
            Door.SetActive(false);
        } 
    }
}
