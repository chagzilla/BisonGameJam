using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public enum MovementType
{
    LEVELSELECTOR,
    TOPDOWN
}

public class Player : MonoBehaviour
{
    private PlayerInput playerInput;
    private Rigidbody2D rb2D;
    private Vector2 dir;
    [SerializeField]
    private MovementType initialMovementType = MovementType.LEVELSELECTOR;
    [SerializeField]
    private float levelSpeed = 1f;
    [SerializeField]
    private float topDownSpeed = 1f;
    private Action movement;
    private MovementType _movementType;
    public MovementType movementType {
        get
        {
            return _movementType;
        }
        set
        {
            
            _movementType = value;
            switch (_movementType)
            {
                case MovementType.LEVELSELECTOR:
                    movement = LevelSelectMovement;
                    break;
                case MovementType.TOPDOWN:
                    movement = TopDownMovement;
                    break;
            }
        }
    }    
    // Start is called before the first frame update

    void Awake()
    {
        if (playerInput == null)
        {
            playerInput = new PlayerInput();
            playerInput.LevelSelector.Disable();
            playerInput.TopDown.Enable();
        }

        rb2D = GetComponent<Rigidbody2D>();
        movementType = initialMovementType;
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }
    private void OnDisable()
    {
        playerInput.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        movement?.Invoke();
    }

    private void TopDownMovement()
    {
        dir = playerInput.TopDown.Move.ReadValue<Vector2>();

        //for top down animations, direction float: 1 = front 2 = back 3 = left 4 =right, walking for wlaking or idle animations

        if (Mathf.RoundToInt(dir.y) == -1)
        {
            GetComponent<Animator>().SetFloat("direction", 1);
            GetComponent<Animator>().SetBool("walking", true);
        }
        else if (Mathf.RoundToInt(dir.y) ==1)
        {
            GetComponent<Animator>().SetFloat("direction", 2);
            GetComponent<Animator>().SetBool("walking", true);
        }
        else if (Mathf.RoundToInt(dir.x) == -1)
        {
            GetComponent<Animator>().SetFloat("direction", 3);
            GetComponent<Animator>().SetBool("walking", true);
        }
        else if (Mathf.RoundToInt(dir.x) ==1)
        {
            GetComponent<Animator>().SetFloat("direction", 4);
            GetComponent<Animator>().SetBool("walking", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("walking", false);
        }

        rb2D.position = rb2D.position + (dir * Time.deltaTime * topDownSpeed); 
    }

    private void LevelSelectMovement()
    {
        dir = playerInput.TopDown.Move.ReadValue<Vector2>();

        //for the animations
        if(Mathf.RoundToInt(dir.x) == 0)
        {
            GetComponent<AudioSource>().volume = 0;
            GetComponent<Animator>().SetBool("moving", false);
        }
        else if(Mathf.RoundToInt(dir.x) > 0)
        {
            GetComponent<AudioSource>().volume = 0.15f;
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<Animator>().SetBool("moving", true);
        }
        else 
        {
            GetComponent<AudioSource>().volume = 0.15f;
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<Animator>().SetBool("moving", true);
        }

        rb2D.position = new Vector2(rb2D.position.x + (dir.x * Time.deltaTime * levelSpeed), rb2D.position.y);
    }

    
    public Vector3 GetPosition() {
        return transform.position;
    }

}
