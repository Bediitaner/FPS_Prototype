using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ProjectH.Scripts.Player
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _prompText;
        
        // Start is called before the first frame update
        void Start()
        {
        }

        public void UpdateText(string promptMessage)
        {
            _prompText.text = promptMessage;
        }
    }
}