using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public PlayerControls playerControls;
    public Vector2 movement;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (playerControls == null)
        {
            playerControls = new PlayerControls();
        }
    }

    private void Awake()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();
        }
        playerControls.Enable();
    }

    void OnEnable()
    {
        playerControls.Player.Move.performed += HandleMove;
    }

    private void OnDisable()
    {
        playerControls.Player.Move.performed -= HandleMove;
        playerControls.Disable();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        HandleLocomotion();
    }

    void HandleLocomotion()
    {
        rb.AddForce(movement);
    }

    void HandleMove(InputAction.CallbackContext context)
    {
        movement  = context.ReadValue<Vector3>();
        Debug.Log(movement);
    }
}
