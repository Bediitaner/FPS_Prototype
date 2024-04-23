using ProjectH.Scripts.UI;
using UnityEngine;

namespace ProjectH.Scripts.Player
{
    public class PlayerStats: MonoBehaviour
    {
        #region Contents

        [SerializeField] private float _maxHealth;
        [SerializeField] private HealthBarUI _healthBarUI;

        #endregion

        #region Fields

        private float _currentHealth;

        #endregion

        #region Unity: Start | Update

        private void Start()
        {
            _currentHealth = _maxHealth;
            
            _healthBarUI.SetSliderMaxValue(_maxHealth);
            _healthBarUI.SetSliderStartingValue(_currentHealth);
            _healthBarUI.SetUIText(_currentHealth,_maxHealth);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                DecreaseHealth(20f);
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                IncreaseHealth(20f);
            }

            if (_currentHealth <= 0)
            {
                Death();
            }
        }

        #endregion
        
        #region Health: Decrease

        public void DecreaseHealth(float damage)
        {
            var cachedValue = _currentHealth;
            
            _currentHealth -= damage;
            _currentHealth = Mathf.Max(_currentHealth, 0);

            _healthBarUI.UpdateSliderValue(_currentHealth);
            _healthBarUI.UpdateUIText(cachedValue,_currentHealth ,_maxHealth);
        }

        #endregion

        #region Health: Increase

        public void IncreaseHealth(float amount)
        {
            var cachedValue = _currentHealth;

            _currentHealth += amount;
            _currentHealth = Mathf.Min(_currentHealth, _maxHealth);

            _healthBarUI.UpdateSliderValue(_currentHealth);
            _healthBarUI.UpdateUIText(cachedValue,_currentHealth ,_maxHealth);
        }

        #endregion
        
        #region Death

        private void Death()
        {
            Debug.Log("Player is Dead!");
            
            //TODO:@Halit: Play Death Animation
            //TODO:@Halit: Activate Death UI 
            //TODO:@Halit: Disable Player Movement
            //TODO:@Halit: Disable Player Look
            //TODO:@Halit: Stop the game
        }

        #endregion
    }
}