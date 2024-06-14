using System;
using System.Collections;
using System.Collections.Generic;
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
        rb2D.position = rb2D.position + (dir * Time.deltaTime * topDownSpeed); 
    }

    private void LevelSelectMovement()
    {
        dir = playerInput.TopDown.Move.ReadValue<Vector2>();
        rb2D.position = new Vector2(rb2D.position.x + (dir.x * Time.deltaTime * levelSpeed), rb2D.position.y);
    }
}
