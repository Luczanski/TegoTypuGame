using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private PlayerControls controls;
    private Vector2 moveInput;
    private BruteMovement bruteMovement;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        controls = new PlayerControls();
        bruteMovement = GetComponent<BruteMovement>();

        controls.Brute.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Brute.Move.canceled += ctx => moveInput = Vector2.zero;

        bruteMovement.OnAttack += HandleAttack;
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
        HandleAnimations();
    }

    private void HandleAnimations()
    {
        bool isWalkingForward = moveInput.y > 0;
        bool isWalkingBack = moveInput.y < 0;
        bool isTurningLeft = moveInput.x < 0;
        bool isTurningRight = moveInput.x > 0;

        animator.SetBool("isWalkF", isWalkingForward);
        animator.SetBool("isWalkB", isWalkingBack);
        animator.SetBool("TurnLeft", isTurningLeft);
        animator.SetBool("TurnRight", isTurningRight);

        if (!isWalkingForward && !isWalkingBack && !isTurningLeft && !isTurningRight)
        {
            animator.SetBool("Idle", true);
        }
        else
        {
            animator.SetBool("Idle", false);
        }
    }

    private void HandleAttack()
    {
        animator.SetTrigger("isAttack");
    }
}
