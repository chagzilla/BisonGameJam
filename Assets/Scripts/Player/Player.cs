using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public enum MovementType
{
    LEVELSELECTOR,
    TOPDOWN,
    SLIDING
}

public class Player : MonoBehaviour
{
    private PlayerInput playerInput;
    private Rigidbody2D rb2D;
    public Vector2 dir;
    [SerializeField]
    private MovementType initialMovementType = MovementType.LEVELSELECTOR;
    [SerializeField]
    private float levelSpeed = 1f;
    [SerializeField]
    public float topDownSpeed = 1f;
    [SerializeField]
    private float topDownSlideForce = 1f;
    [SerializeField]
    private float topDownSlideLimit = 10f;
    private Action movement;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private Image heatGuage;
    [SerializeField]
    private float heatTimerLimit = 20f;
    private float heatTimer = 20f;
    private float heatValue;
    [SerializeField]
    private float heatingSpeed = 2f;
    bool isWarming = false;
    [SerializeField]
    private Color barStartColor;
    [SerializeField]
    private Color barEndColor;
    public bool isTouchingGround = true;
    public bool canJump = true;

    //public InputActionReference follow;
    //public InputActionReference follow;
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
                case MovementType.SLIDING:
                    movement = SlidingMovement;
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
        heatTimer = heatTimerLimit;
    }

    private void OnEnable()
    {
        playerInput.Enable();
        //follow.action.started += Follow;
    }
    private void OnDisable()
    {
        playerInput.Disable();
        //follow.action.started -= Follow;
    }

    // Update is called once per frame
    void Update()
    {
        movement?.Invoke();
        if (slider != null) 
        {
            heatValue = Mathf.Max(heatTimer, 0f) / heatTimerLimit;
            slider.value = heatValue;
            if (!isWarming) 
            {
                heatTimer -= Time.deltaTime;
            }
            else
            {
                heatTimer = Mathf.Min(Time.deltaTime * heatingSpeed + heatTimer, heatTimerLimit);
            }
            heatGuage.color = Color.Lerp(barEndColor, barStartColor, heatValue);
            if (heatValue <= 0f)
            {
                transform.position = (Checkpoints.Instance.checkpoints[0] + Vector3.back);
                heatTimer = heatTimerLimit;
            }
        }
    }

    private void SlidingMovement()
    {
        dir = playerInput.TopDown.Move.ReadValue<Vector2>();
        //for top down animations, direction float: 1 = front 2 = back 3 = left 4 =right, walking for wlaking or idle animations

        if (Mathf.RoundToInt(dir.y) == -1)
        {
            GetComponent<Animator>().SetFloat("direction", 1);
            GetComponent<Animator>().SetBool("walking", true);
        }
        else if (Mathf.RoundToInt(dir.y) == 1)
        {
            GetComponent<Animator>().SetFloat("direction", 2);
            GetComponent<Animator>().SetBool("walking", true);
        }
        else if (Mathf.RoundToInt(dir.x) == -1)
        {
            GetComponent<Animator>().SetFloat("direction", 3);
            GetComponent<Animator>().SetBool("walking", true);
        }
        else if (Mathf.RoundToInt(dir.x) == 1)
        {
            GetComponent<Animator>().SetFloat("direction", 4);
            GetComponent<Animator>().SetBool("walking", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("walking", false);
        }

        if (dir != Vector2.zero)
        {



            rb2D.AddForce(dir * Time.deltaTime * topDownSlideForce);


            if (rb2D.velocity.magnitude >= topDownSlideLimit)
            {
                rb2D.AddForce((rb2D.velocity.normalized * -1f * topDownSlideForce) * Time.deltaTime);
            }
        }

        Debug.Log("Magnitude of velocity: " + rb2D.velocity.magnitude);
        
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

        if (canJump && isTouchingGround && playerInput.LevelSelector.Jump.IsPressed())
        {
            rb2D.velocity = Vector2.up * 5;
            canJump = false;
        }
    }

    
    public Vector3 GetPosition() {
        return transform.position;
    }


    private void Follow(InputAction.CallbackContext obj)
    {
        Debug.Log("SPACE");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fire")
        {
            isWarming = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Fire")
        {
            isWarming = false;
        }
    }
}
