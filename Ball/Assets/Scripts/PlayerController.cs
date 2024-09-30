using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    private PlayerControls _playerControls;
    public Vector2 movement;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (_playerControls == null)
        {
            _playerControls = new PlayerControls();
        }

        speed = 3f;
    }

    private void Awake()
    {
        if (_playerControls == null)
        {
            _playerControls = new PlayerControls();
        }
        _playerControls.Enable();
    }

    void OnEnable()
    {
        _playerControls.Player.Move.performed += HandleMove;
    }

    private void OnDisable()
    {
        _playerControls.Player.Move.performed -= HandleMove;
        _playerControls.Disable();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        HandleLocomotion();
    }

    void HandleLocomotion()
    {
        Vector3 moveVector = new Vector3(movement.x, 0, movement.y);
        rb.AddForce(moveVector * speed);
        Debug.Log(moveVector);
    }

    void HandleMove(InputAction.CallbackContext context)
    {
        movement  = context.ReadValue<Vector2>();
        Debug.Log(movement);
    }
}
