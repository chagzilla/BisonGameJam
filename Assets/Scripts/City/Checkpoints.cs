using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public static Checkpoints Instance;

    public Vector3[] checkpoints;
    public Transform bison;
    public int currentpoint = 0;
    public bool useYValue = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
 
    void Update()
    {
        if (useYValue)
        {
            if (bison.position.y >= checkpoints[currentpoint + 1].y)
            {
                currentpoint += 1;
            }
        }
        else
        {
            if ((currentpoint + 1) < checkpoints.Length && bison.position.x >= checkpoints[currentpoint + 1].x)
            {
                currentpoint += 1;
            }
        }
    }
}
