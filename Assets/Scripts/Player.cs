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

    #endregion

    [Header("Player properties")]
    [SerializeField] private float WalkSpeed;
    public bool CanMove = true;
    public string AreaTransitionName;

    public float FacingDir { get; private set; } = 1;
    private bool FacingRight = true;

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
        FlipController(_xVelocity);
        Rb.velocity = new Vector2(_xVelocity, _yVelocity) * WalkSpeed;
    }


    /*
     * float x = Horizontal input
     * 
     * Description: function that set the facing direction.
     * 
     * 
    */
    private void FlipController(float x)
    {
        if (x > 0 && !FacingRight)
            Flip();
        else if (x < 0 && FacingRight)
            Flip();
    }

    private void Flip()
    {
        FacingDir *= -1;
        FacingRight = !FacingRight;
        transform.Rotate(0, 180, 0);
    }

}
