using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Animator Animator { get; private set; }
    public Rigidbody2D Rb { get; private set; }
    public float XFacingDir { get; private set; } = 0;
    public float YFacingDir { get; private set; } = 0;

    public const string XDirection = "xDirection";
    public const string YDirection = "yDirection";

    [Header("Player properties")]
    [SerializeField] private float walkSpeed;

    #region States
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerMovementState playerMovementState { get; private set; }
    public PlayerIdleState playerIdleState { get; private set; }
    #endregion

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();
        playerMovementState = new PlayerMovementState(this, stateMachine, "isWalking");
        playerIdleState = new PlayerIdleState(this, stateMachine, "isIdle");

    }
    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponentInChildren<Animator>();
        Rb = GetComponent<Rigidbody2D>();

        // initialize state machine
        stateMachine.Initialize(playerIdleState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.currentState.Update();
    }

    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        FlipController(_xVelocity, _yVelocity);
        Rb.velocity = new Vector2(_xVelocity, _yVelocity) * walkSpeed;
    }

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
