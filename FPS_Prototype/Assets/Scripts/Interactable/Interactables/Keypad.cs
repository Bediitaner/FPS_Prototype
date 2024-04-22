using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectH.Scripts.Player
{
    public class Keypad : Interactable
    {
        #region Contents

        [SerializeField] private GameObject _door;

        [SerializeField] private Animator _animator;

        #endregion

        #region Fields

        private bool _doorOpen;

        #endregion

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        //this function is where will design our interaction using code.
        protected override void Interact()
        {
            _doorOpen = !_doorOpen;
            _animator.SetBool("IsOpen", _doorOpen);
        }
    }
}