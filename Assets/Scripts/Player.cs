using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Animator animator { get; private set; }
    public Rigidbody2D rb { get; private set; }

    [Header("Player properties")]
    [SerializeField] private float walkSpeed;

    #region States

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        setVelocity(x, y);
    }

    public void setVelocity(float _xVelocity, float _yVelocity)
    {
        FlipController(_xVelocity, _yVelocity);
        rb.velocity = new Vector2(_xVelocity, _yVelocity) * walkSpeed;
    }

    private void FlipController(float x, float y)
    {
        Debug.Log("get Direction");
    }

}
