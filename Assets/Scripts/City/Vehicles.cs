using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vehicles : MonoBehaviour
{
    public Vector3 Movedirection;
    public float speed;
    public bool turning = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().position += Movedirection * speed * Time.deltaTime;
        if (turning)
        {
            GetComponent<Transform>().rotation *= Quaternion.Euler(0, 0, Time.deltaTime * 270);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (SceneManager.GetActiveScene().name == "Desert")
            {
                other.gameObject.GetComponent<Transform>().position = Checkpoints.Instance.checkpoints[Checkpoints.Instance.currentpoint];
                GameObject.FindWithTag("UFO").GetComponent<Transform>().position = Checkpoints.Instance.checkpoints[Checkpoints.Instance.currentpoint];
            }
            else
            {
                other.gameObject.GetComponent<Transform>().position = Checkpoints.Instance.checkpoints[Checkpoints.Instance.currentpoint];
                Destroy(gameObject);
            }
        }
    }
}
