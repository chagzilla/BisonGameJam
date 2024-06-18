using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class WolfWaypoints : MonoBehaviour
{
    [SerializeField] private GameObject waypoint1;
    [SerializeField] private GameObject waypoint2;
    private NavMeshAgent agent;
    [SerializeField] private Player player;

    [SerializeField] private GameObject companion;
    
    [SerializeField] private float range;
    private float waypointIndex = 1;

    private float walking = 0;


    private void Start(){
        
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update(){

        if(Vector3.Distance(transform.position,player.transform.position) < range || Vector3.Distance(transform.position,companion.transform.position)  < range )
        {
            
            walking = 0;
            waypointIndex = 3;
            if(Vector3.Distance(transform.position,player.transform.position) < Vector3.Distance(transform.position,companion.transform.position))
            {
                
                agent.SetDestination(player.transform.position);
            }
            else
            {
                agent.SetDestination(companion.transform.position);
            }
        }
        else if (walking == 0 )
        {
            waypointIndex = 1;
                                    
            agent.SetDestination(waypoint1.transform.position);
            walking =1;
            WalkingBetweenWaypoints();
        }
        else if (walking == 1)
        {
            WalkingBetweenWaypoints();
        }

        }

        
        private void OnCollisionEnter2D(Collision2D collision)
            {

            
                if (collision.gameObject.CompareTag("Player"))
                {
                    
                    SceneManager.LoadScene("Forest Final");

                }
                else if (collision.gameObject.CompareTag("Companion"))
                {
                    
                    SceneManager.LoadScene("Forest Final");
                }
            }
    
        private void WalkingBetweenWaypoints()
        {
            if(waypointIndex == 1){
                if(Vector3.Distance(transform.position,waypoint1.transform.position) <= 0.6 && waypointIndex == 1)
                    {
                        
                        agent.SetDestination(waypoint2.transform.position);
                        Debug.Log("Reached Waypoint 1");
                        waypointIndex = 2;
                        walking = 1;    
                    }
                    
                if(Vector3.Distance(transform.position,waypoint1.transform.position) >= 0.6 && waypointIndex == 1){
                    
                        agent.SetDestination(waypoint1.transform.position);
                }
            }
             if(waypointIndex == 2)
            {
                if(Vector3.Distance(transform.position,waypoint2.transform.position) <= 0.6 && waypointIndex == 2)
                    {
                        
                        agent.SetDestination(waypoint1.transform.position);
                        
                        Debug.Log("Reached Waypoint 2");
                        waypointIndex = 1;
                        walking = 1;
                    }
                    if(Vector3.Distance(transform.position,waypoint2.transform.position) >= 0.6 && waypointIndex == 1){
                    
                        agent.SetDestination(waypoint2.transform.position);
                }
            }
        }   
 }
 
    

