using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vehicle_Spawner : MonoBehaviour
{
    public GameObject[] vehicles;
    public float interval;
    public float delay;
    private float timer;
    public Vector3 vehicle_direction;
    public float vehicle_speed;
    public bool OnlyWhenPlayerNear = false;
    private bool insidecollider;
    public bool barthrower = false;
    public bool mofas = false;
    public bool laser = false;
    void Start()
    {
        timer = delay;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <=0 )
        {
            if (!OnlyWhenPlayerNear || insidecollider)
            {
                if(barthrower) 
                { 
                    vehicle_direction = (GameObject.FindWithTag("Player").GetComponent<Transform>().position - GetComponent<Transform>().position).normalized;
                    if(SceneManager.GetActiveScene().name == "Desert")
                    {
                        vehicle_direction = (GameObject.FindWithTag("Player").GetComponent<Transform>().position + new Vector3(.4f,Random.Range(-100,101)/100,0) - GetComponent<Transform>().position ).normalized;
                    }
                }
                if (laser)
                {
                    GameObject v = Instantiate(vehicles[Random.Range(0, vehicles.Length)], GetComponent<Transform>().position, Quaternion.identity);
                    v.GetComponent<Vehicles>().speed = 0;
                    v.GetComponent<Vehicles>().Movedirection = new Vector3(0,0,0);
                    Destroy(v, 2);
                }
                else if (!mofas)
                {
                    GameObject v = Instantiate(vehicles[Random.Range(0, vehicles.Length)], GetComponent<Transform>().position, Quaternion.identity);
                    v.GetComponent<Vehicles>().speed = vehicle_speed;
                    v.GetComponent<Vehicles>().Movedirection = vehicle_direction;
                    Destroy(v, 10);
                }
                else
                {
                    GameObject v = Instantiate(vehicles[Random.Range(0, vehicles.Length)], GetComponent<Transform>().position + new Vector3(Random.Range(-3,3),0,0), Quaternion.identity);
                    v.GetComponent<Vehicles>().speed = vehicle_speed;
                    v.GetComponent<Vehicles>().Movedirection = vehicle_direction;
                    Destroy(v, 10);
                }

                timer = interval;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            insidecollider = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            insidecollider = false;
        }
    }
}
