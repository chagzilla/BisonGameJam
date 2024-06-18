using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    [SerializeField] private int pressurePlateNo;
    public PressurePlateManager pressurePlateManager;
    private void OnTriggerStay2D(Collider2D other){

        if(other.tag == "Player" || other.tag == "Companion")
        {   
            switch(pressurePlateNo){
                case 1:
                pressurePlateManager.Plate1 = true;
                break;
                case 2:
                pressurePlateManager.Plate2 = true;
                break;   
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other){
 switch(pressurePlateNo){
                case 1:
                pressurePlateManager.Plate1 = false;
                break;
                case 2:
                pressurePlateManager.Plate2 = false;
                break;
            }
    }
}
