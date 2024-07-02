using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteMovement : MonoBehaviour
{
    private PlayerControls controls;
    private Vector2 moveInput;
    private bool movementPressed;
    [SerializeField] private GameObject Player;
    public float moveSpeed = 3.0f;
    public float turnSpeed = 200f;
    private Rigidbody rb;
    private bool isAttacking;

    public event Action OnAttack;

    private void Awake()
    {
        controls = new PlayerControls();
        rb = GetComponent<Rigidbody>();

        controls.Brute.Move.performed += ctx =>
        {
            moveInput = ctx.ReadValue<Vector2>();
            movementPressed = moveInput.x != 0 || moveInput.y != 0;
        };
        controls.Brute.Move.canceled += ctx => moveInput = Vector2.zero;
        controls.Brute.Attack.performed += ctx => HandleAttack();
    }

    private void OnEnable()
    {
        controls.Brute.Enable();
    }

    private void OnDisable()
    {
        controls.Brute.Disable();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 move = transform.forward * moveInput.y * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + move);

        Rotate();
    }

    private void Rotate()
    {
        float turn = moveInput.x * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    private void HandleAttack()
    {
        if (OnAttack != null)
        {
            OnAttack.Invoke();
        }
        isAttacking = true;
    }
}

