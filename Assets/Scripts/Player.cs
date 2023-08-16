using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Player : MonoBehaviour
{

    // Player Instance
    public static Player Instance { get; private set; }


    #region Player Components, and variables
    public Animator Animator { get; private set; }
    public Rigidbody2D Rb { get; private set; }
    public float XFacingDir { get; private set; } = 0;
    public float YFacingDir { get; private set; } = 0;

    public const string XDirection = "xDirection";
    public const string YDirection = "yDirection";
    #endregion

    [Header("Player properties")]
    [SerializeField] private float walkSpeed;
    public string areaTransitionName;


    #region States
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerMovementState playerMovementState { get; private set; }
    public PlayerIdleState playerIdleState { get; private set; }
    #endregion

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        // Creating an instance of the State machine 
        stateMachine = new PlayerStateMachine();
        
        // Creating an instance of every state of the player.
        playerMovementState = new PlayerMovementState(this, stateMachine, "isWalking");
        playerIdleState = new PlayerIdleState(this, stateMachine, "isIdle");

    }
    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponentInChildren<Animator>();
        Rb = GetComponent<Rigidbody2D>();

        // persistance of the player with DontDestroyOnLoad

        DontDestroyOnLoad(gameObject);

        // initialize state machine
        stateMachine.Initialize(playerIdleState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.currentState.Update();
    }

    /*
     * float x = Horizontal input
     * float y = Vertical Input
     * 
     * Description: use the Inputs of the player to move the character using the RigidBody Velocity.
     *  
     */
    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        FlipController(_xVelocity, _yVelocity);
        Rb.velocity = new Vector2(_xVelocity, _yVelocity) * walkSpeed;
    }


    /*
     * float x = Horizontal input
     * float y = Vertical Input
     * 
     * Description: function that set the x and y direction of the player.
     * 
     * 
    */
    private void FlipController(float x, float y)
    {
        if (x != 0 | y != 0)
        {
            XFacingDir = x;
            YFacingDir = y;
            Animator.SetFloat(XDirection, XFacingDir);
            Animator.SetFloat(YDirection, YFacingDir);
        }
    }

}
