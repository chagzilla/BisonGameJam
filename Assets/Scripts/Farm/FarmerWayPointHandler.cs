using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Character moves between waypoints
 * */
public class FarmerWayPointHandler : MonoBehaviour {
        
    [SerializeField]private  float speed = 25f;

    [SerializeField] private List<Vector3> waypointList;
    [SerializeField] private List<float> waitTimeList;
    private int waypointIndex;


    [SerializeField] private float idleFrameRate;
    [SerializeField] private float walkFrameRate ;
    [SerializeField] private Vector3 aimDirection;

    [SerializeField] private Player player;
    [SerializeField] private Transform pfFieldOfView;
    [SerializeField] private float fov ;
    [SerializeField] private float viewDistance;

    private FieldOfView fieldOfView;


    private enum State {
        Waiting,
        Moving,
        Busy,
    }

    private State state;
    private float waitTimer;
    private Vector3 lastMoveDir;

    private void Start() {
        state = State.Waiting;
        waitTimer = waitTimeList[0];
        lastMoveDir = aimDirection;

        fieldOfView = Instantiate(pfFieldOfView, null).GetComponent<FieldOfView>();
        fieldOfView.SetFoV(fov);
        fieldOfView.SetViewDistance(viewDistance);
    }

    private void Update() {
        switch (state) {
        default:
        case State.Waiting:
        case State.Moving:
            HandleMovement();
            FindTargetPlayer();
            break;
        case State.Busy:
            break;
        }

        if (fieldOfView != null) {
            fieldOfView.SetOrigin(transform.position);
            fieldOfView.SetAimDirection(GetAimDir());
        }

        Debug.DrawLine(transform.position, transform.position + GetAimDir() * 10f);
    }

    private void FindTargetPlayer() {
        if (Vector3.Distance(GetPosition(), player.GetPosition()) < viewDistance) {
            // Player inside viewDistance
            Vector3 dirToPlayer = (player.GetPosition() - GetPosition()).normalized;
            if (Vector3.Angle(GetAimDir(), dirToPlayer) < fov / 2f) {
                // Player inside Field of View
                RaycastHit2D raycastHit2D = Physics2D.Raycast(GetPosition(), dirToPlayer, viewDistance);
                if (raycastHit2D.collider != null) {
                    // Hit something
                    if (raycastHit2D.collider.gameObject.GetComponent<Player>() != null) {
                        // END GAME
                        
                        SceneManager.LoadScene("Farm");
                    }
                }
            }
        }
    }


    private void HandleMovement() {
        switch (state) {
        case State.Waiting:
            waitTimer -= Time.deltaTime;
           
            if (waitTimer <= 0f) {
                state = State.Moving;
            }
            break;
        case State.Moving:
            Vector3 waypoint = waypointList[waypointIndex];

            Vector3 waypointDir = (waypoint - transform.position).normalized;
            lastMoveDir = waypointDir;

            float distanceBefore = Vector3.Distance(transform.position, waypoint);
           
            transform.position = transform.position + waypointDir * speed * Time.deltaTime;
            float distanceAfter = Vector3.Distance(transform.position, waypoint);

            float arriveDistance = .1f;
            if (distanceAfter < arriveDistance || distanceBefore <= distanceAfter) {
                // Go to next waypoint
                waitTimer = waitTimeList[waypointIndex];
                waypointIndex = (waypointIndex + 1) % waypointList.Count;
                state = State.Waiting;
            }
            break;
        }
    }

    public Vector3 GetPosition() {
        return transform.position;
    }

    public Vector3 GetAimDir() {
        return lastMoveDir;
    }

}
