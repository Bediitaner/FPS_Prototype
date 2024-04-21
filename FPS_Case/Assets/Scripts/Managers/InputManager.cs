using System;
using FPS_Case.Scripts.Movement;
using UnityEngine;

namespace FPS_Case.Scripts.Managers
{
    public class InputManager: MonoBehaviour
    {

        private PlayerInput _playerInput;
        private PlayerInput.OnFootActions onFoot;

        private PlayerMotor motor;
        private PlayerLook look;
        
        #region Unity

        private void Awake()
        {
            _playerInput = new PlayerInput();
            onFoot = _playerInput.OnFoot;
            
            motor = GetComponent<PlayerMotor>();
            look = GetComponent<PlayerLook>();
            
            onFoot.Jump.performed += ctx => motor.Jump();
            onFoot.Sprint.performed += ctx => motor.Sprint();
            onFoot.Crouch.performed += ctx => motor.Crouch();
        }
        private void FixedUpdate()
        {
            motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
        }

        private void LateUpdate()
        {
            look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
        }

        private void OnEnable()
        {
            onFoot.Enable();
        }

        private void OnDisable()
        {
            onFoot.Disable();
        }

        #endregion
    }
}