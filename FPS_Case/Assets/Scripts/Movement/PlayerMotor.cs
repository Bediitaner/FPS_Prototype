using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS_Case.Scripts.Movement
{
    public class PlayerMotor : MonoBehaviour
    {

        #region Properties

        public float _gravity = -9.8f;
        public float _speed = 5f;
        public float _jumpHeight= 1f;

        #endregion
        
        #region Fields

        private CharacterController _controller;
        private Vector3 _playerVelocity;
        private bool _isGrounded;
        private bool _sprinting;
        private bool _crouching;
        private bool _lerpCrouch;
        private float _crouchTimer;

        #endregion
        

        #region Unity: Start | Update

        private void Start()
        {
            _controller = GetComponent<CharacterController>();
            
            SetCursor();
        }

        private void Update() 
        {
            _isGrounded = _controller.isGrounded;

            if (_lerpCrouch)
            {
                _crouchTimer += Time.deltaTime;
                float progress = _crouchTimer / 1 ;
                progress *= progress;

                if (_crouching)
                    _controller.height = Mathf.Lerp(_controller.height, 1, progress);
                else
                    _controller.height = Mathf.Lerp(_controller.height, 2, progress);

                if (progress > 1)
                {
                    _lerpCrouch = false;
                    _crouchTimer = 0f;
                }
            }
        }

        #endregion



        #region Process: Move

        public void ProcessMove(Vector2 input)
        {
            var moveDirection = Vector3.zero;
            moveDirection.x = input.x;
            moveDirection.z = input.y;
            _controller.Move(transform.TransformDirection(moveDirection) * _speed * Time.deltaTime);

            _playerVelocity.y += _gravity * Time.deltaTime;
            if (_isGrounded && _playerVelocity.y < 0)
            {
                _playerVelocity.y = -2f;
            }
            _controller.Move(_playerVelocity * Time.deltaTime);
        }

        #endregion

        public void Jump()
        {
            if (_isGrounded)
            {
                _playerVelocity.y = Mathf.Sqrt(_jumpHeight * -3.0f * _gravity);
            }
        }

        public void Sprint()
        {
            _sprinting = !_sprinting;
            if (_sprinting)
                _speed = 8;
            else
                _speed = 5;
        }

        public void Crouch()
        {
            _crouching = !_crouching;
            _crouchTimer = 0;
            _lerpCrouch = true;
        }
        
        #region Set: Cursor

        private void SetCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        #endregion
    }
}