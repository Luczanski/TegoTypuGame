using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemPlayer : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    PlayerInput playerInput;
   
   public InputAction moveAction;
    private InputActionMap Player;
    [SerializeField] private float playerSpeed;
    
    //For animations
     Animator animator;
     int isWalkingForward;
     int isWalkingBack;

     private void Awake()
     {
         playerInput = GetComponent<PlayerInput>();
         
         moveAction = playerInput.actions.FindAction("MoveActions");
         //moveAction = playerInput.currentActionMap.actions;
         moveAction.performed += ctx => Debug.Log(ctx.ReadValueAsButton());

     }

     private void Start()
    {
       // playerInput = GetComponent<PlayerInput>();
        //moveAction = playerInput.actions.FindAction("Movement");

       // Player = playerInput.actions.FindActionMap("Player");
       // moveAction = Player.FindAction("Movement");

        animator = GetComponent<Animator>();
        isWalkingForward = Animator.StringToHash("isWalkingForward");
        isWalkingBack = Animator.StringToHash("isWalkingBack");
        
    }

    private void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
       
      //  Vector2 direction = moveAction.ReadValue<Vector2>();
     //   transform.position += new Vector3(direction.x, 0, direction.y) * playerSpeed * Time.deltaTime;
        Debug.Log("move");
    }

    void handleMovement()
    {
        //get parameter values form animator
        bool isRunningForward = animator.GetBool(isWalkingForward);
        bool isRunningBack = animator.GetBool(isWalkingBack);

    }
    
   
}


