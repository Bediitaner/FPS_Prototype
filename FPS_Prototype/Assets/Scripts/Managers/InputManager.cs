using System;
using ProjectH.Scripts.Player;
using UnityEngine;

namespace ProjectH.Scripts.Managers
{
    public class InputManager: MonoBehaviour
    {
        #region Fields

        private PlayerInput _playerInput;
        
        private PlayerInput.OnFootActions _onFoot;
        public PlayerInput.OnFootActions OnFoot => _onFoot;

        private PlayerMotor _motor;
        private PlayerLook _look;

        #endregion
        
        #region Unity

        private void Awake()
        {
            _playerInput = new PlayerInput();
            _onFoot = _playerInput.OnFoot;
            
            _motor = GetComponent<PlayerMotor>();
            _look = GetComponent<PlayerLook>();
            
            _onFoot.Jump.performed += ctx => _motor.Jump();
            _onFoot.Sprint.performed += ctx => _motor.Sprint();
            _onFoot.Crouch.performed += ctx => _motor.Crouch();
        }
        private void FixedUpdate()
        {
            
        }

        private void LateUpdate()
        {
            _motor.ProcessMove(_onFoot.Movement.ReadValue<Vector2>());
            _look.ProcessLook(_onFoot.Look.ReadValue<Vector2>());
        }

        private void OnEnable()
        {
            _onFoot.Enable();
        }

        private void OnDisable()
        {
            _onFoot.Disable();
        }

        #endregion
    }
}