using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wolf : MonoBehaviour
{
    [SerializeField] Transform Bison;
    [SerializeField] Transform Companion;

    NavMeshAgent agent;

    private void Start(){
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, Bison.transform.position) < 1){
            
            Debug.Log("PLAYER IN RANGE");
        }
        //agent.SetDestination(target.position);
    }


    private void OnTriggerStay2D(Collider2D other){
        
        if(other.tag== "Companion")
        {
            agent.SetDestination(Companion.position);
        }
        if(other.tag == "Player")
        {
            agent.SetDestination(Bison.position);
        }
    }
}
