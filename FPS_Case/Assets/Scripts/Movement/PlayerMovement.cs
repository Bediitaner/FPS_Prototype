using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS_Case.Scripts.Movement
{
    public class FPSController : MonoBehaviour
    {
        #region Content

        [SerializeField] private CharacterController characterController;
        [SerializeField] private Camera _playerCamera;
        [SerializeField] private float _walkingSpeed;
        [SerializeField] private float _runningSpeed;
        [SerializeField] private float _jumpSpeed;
        [SerializeField] private float _gravity;
        [SerializeField] private float _lookSpeed;
        [SerializeField] private float _lookXLimit;

        #endregion

        #region Fields

        private Vector3 moveDirection = Vector3.zero;
        private float rotationX = 0;
        private bool canMove = true;

        #endregion

        #region Unity: Start | Update

        private void Start()
        {
            characterController = GetComponent<CharacterController>();

            SetCursor();
        }

        public void Update()
        {
            Movement();
        }

        #endregion
        
        
        #region Movement

        private void Movement()
        {
            var forward = transform.TransformDirection(Vector3.forward);
            var right = transform.TransformDirection(Vector3.right);
            var isRunning = Input.GetKey(KeyCode.LeftShift);
            var currentSpeedX = canMove ? (isRunning ? _runningSpeed : _walkingSpeed) * Input.GetAxis("Vertical") : 0;
            var currentSpeedY = canMove ? (isRunning ? _runningSpeed : _walkingSpeed) * Input.GetAxis("Horizontal") : 0;
            var movementDirectionY = moveDirection.y;
            moveDirection = (forward * currentSpeedX) + (right * currentSpeedY);

            if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
            {
                moveDirection.y = _jumpSpeed;
            }
            else
            {
                moveDirection.y = movementDirectionY;
            }


            if (!characterController.isGrounded)
            {
                moveDirection.y -= _gravity * Time.deltaTime;
            }

            characterController.Move(moveDirection * Time.deltaTime);

            if (canMove)
            {
                rotationX += -Input.GetAxis("Mouse Y") * _lookSpeed;
                rotationX = Mathf.Clamp(rotationX, -_lookXLimit, _lookXLimit);
                _playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * _lookSpeed, 0);
            }
        }

        #endregion

        #region Set: Cursor

        private void SetCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        #endregion
        
    }
}