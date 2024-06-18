using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonObject : MonoBehaviour
{
    [SerializeField]private GameObject Button;
    [SerializeField]private ButtonManager buttonManager;
    [SerializeField] private float buttonNO;
           
           
        private void OnTriggerStay2D(Collider2D other){

        if(other.tag == "Player" )
        {   
            switch(buttonNO){
                case 1:
                buttonManager.Button1 = true;
                break;
                case 2:
                buttonManager.Button2 = true;
                break;   
                case 3:
                buttonManager.Button3 = true;
                break;
            }

            Button.SetActive(false);
        }
    }
}

