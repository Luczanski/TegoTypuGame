using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteMovement : MonoBehaviour
{
    Animator animator;
    int isWalkingForward;
    int isWalkingBack;
    
    
    private PlayerControls controls;

    Vector2 moveInput;
    private bool movementPresed;
    
    public float mspeed = 3.0f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    private void Awake()
    {
        controls = new PlayerControls();

        controls.Brute.Move.performed += ctx =>
        {
            moveInput = ctx.ReadValue<Vector2>();
            movementPresed = moveInput.x != 0 || moveInput.y != 0;
        };
        controls.Brute.Move.canceled += ctx => moveInput = Vector2.zero;
        controls.Brute.Move.performed += ctx => Debug.Log(ctx.ReadValueAsObject());
    }

    private void OnEnable()
    {
        controls.Brute.Enable();
    }

    private void OnDisable()
    {
        controls.Brute.Disable();
    }
    void Update()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y) * mspeed * Time.deltaTime;
        transform.Translate(move, Space.World);


        bool isWalkingForward= moveInput != Vector2.zero;
        animator.SetBool("isWalkF",isWalkingForward);

        if (!isWalkingForward)
        {
            animator.SetBool("isWalkF",false);
        }
        float speed = move.magnitude / Time.deltaTime; // Aktualna prędkość ruchu
        animator.SetFloat("Speed", speed);

        // Jeśli gracz się nie porusza, dezaktywuj animację ruchu
        if (!isWalkingForward)
        {
            animator.SetFloat("Speed", 0);
            animator.SetFloat("Forward", 0);
        }
        else
        {
            // Sprawdzenie czy gracz idzie do przodu czy do tyłu
            if (moveInput.y > 0)
            {
                // Poruszanie się do przodu
                animator.SetFloat("Forward", 1);
            }
            else if (moveInput.y < 0)
            {
                // Poruszanie się do tyłu
                animator.SetFloat("Forward", -1);
            }
            else
            {
                // Jeśli nie ma ruchu w osi Z, ustawiamy 0
                animator.SetFloat("Forward", 0);
            }
        }
    }
   
    }

