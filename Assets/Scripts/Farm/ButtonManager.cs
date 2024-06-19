using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    [SerializeField] private GameObject Door1;

    [SerializeField] private GameObject Door2;
    [SerializeField] private GameObject HelpTip;

    public bool Button1 =false;
    public bool Button2 =false;
    
    public bool Button3 =false;

    private void Update()
    {
        if (Button1 && Button2 && Button3)
        {
            Door1.SetActive(false);
            Door2.SetActive(false);
            HelpTip.SetActive(false);
        }
    }


}
