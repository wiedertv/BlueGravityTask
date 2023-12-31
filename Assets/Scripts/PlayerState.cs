using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected float xInput;
    protected float yInput;
    protected PlayerStateMachine stateMachine;
    protected Player player;

    private string animBoolName;

    public PlayerState(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName)
    {
        this.player = _player;
        this.stateMachine = _playerStateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        player.Animator.SetBool(animBoolName, true);
    }

    public virtual void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

    }

    public virtual void Exit()
    {
        player.Animator.SetBool(animBoolName, false);
    }
}
