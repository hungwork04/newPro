using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Vector2 moveInput;
    public float walkSpeed = 10f;
    Animator animator;
    private bool _isMoving=false;
    public float jumpForce = 6f;

    bool _isFacingRight = true;


   public bool IsMoving
    {
        get
        {
            return _isMoving;
        }
        set
        {
            _isMoving = value;
            animator.SetBool("isMoving", value);
        }
    }
    Rigidbody2D rb;
    public bool isFacingRight {
        get { return _isFacingRight; }
        private set
        {
            if (_isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1, 1);
            }
            _isFacingRight=value;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = rb.GetComponent<Animator>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * walkSpeed, rb.velocity.y);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput=context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;

        setFacingRightLeft(moveInput);
    }

    private void setFacingRightLeft(Vector2 moveInput)
    {
        if(moveInput.x>0 && !isFacingRight)
        {
            isFacingRight=true;
        }
        else if(moveInput.x<0 && isFacingRight)
        {
            isFacingRight = false;
        }
    }
}
