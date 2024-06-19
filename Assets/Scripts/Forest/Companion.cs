using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Companion : MonoBehaviour
{
    [SerializeField] Transform Bison;
    
   // public InputActionReference follow;

    private NavMeshAgent agent;
    [SerializeField] private float speed;
    
    [SerializeField] private float range;
    
    [SerializeField] private Animator animator;
    private bool isFollowing = true;
    
    private float Direction;
    private Vector3 currentLocation;
    private Vector3 lastLocation = Vector3.zero;

    private void OnEnable()
    {
       // follow.action.started += Follow;
    }


    
    private void OnDisable()
    {
        //follow.action.started -= Follow;
    }

    private void Awake(){
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = 0;
        
        currentLocation = transform.position;
    }
    // Update is called once per frame
    
    private void OnTriggerStay2D(Collider2D other){
        if(other.tag == "Player")
        {
            agent.SetDestination(Bison.position);
        }
    }
private void Update(){


        
        lastLocation=currentLocation;
        currentLocation = transform.position;
        Direction = (lastLocation.x- currentLocation.x);
        Debug.Log(Direction);
        
        animator.SetFloat("Direction", Direction);
        if (Input.GetKeyDown(KeyCode.F))
        {
            
             Debug.Log("COMPANION");
             Debug.Log(isFollowing);
                if(isFollowing == true )
                    {
                        agent.speed = speed;
                        isFollowing = false;
            
            
                    }
                else if(isFollowing == false)
                    {
                         agent.speed= 0;
                        isFollowing = true;
                    }

        } 

        if(Vector3.Distance(transform.position,Bison.transform.position) < range && isFollowing == true)
        {
            
            agent.SetDestination(Bison.position);
        }

                if(Vector3.Distance(transform.position,Bison.transform.position) > range)
                {
                    
            agent.speed= 0;
            isFollowing = false;
                }

        
 
        }
    
    /*private void Follow(InputAction.CallbackContext obj)
    {
        
        Debug.Log("COMPANION");
        Debug.Log(isFollowing);
        if(isFollowing == true )
        {
            agent.speed = speed;
            isFollowing = false;
            
            
        }
        else if(isFollowing == false)
        {
            agent.speed= 0;
            isFollowing = true;
        }
    }*/
}

