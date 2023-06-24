using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private Inputaction inputAction;
    public Inputaction.OnFootActions onFoot;

    private PlayerMov motor;
    private PlayerLook look;
    // Start is called before the first frame update
    private void Start()
    {
        
    }
    void Awake()
    {
        inputAction = new Inputaction();
        onFoot = inputAction.OnFoot;

        motor = GetComponent<PlayerMov>();
        look = GetComponent<PlayerLook>();

        onFoot.Jump.performed += ctx => motor.Jump();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //tell the PlayerMov to move using the value from our movement action
        motor.PlayerMovement(onFoot.Movement.ReadValue<Vector2>());

    }

    void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
