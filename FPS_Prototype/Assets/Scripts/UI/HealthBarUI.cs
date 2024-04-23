using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthBarUI : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TextMeshProUGUI _txtHealth;

        public void SetSlider(float amount)
        {
            _slider.value = amount;
        }

        public void SetSliderMax(float amount)
        {
            _slider.maxValue = amount;
            SetSlider(amount);
        }

        public void SetUIText(float currentHealth, float maxHealth)
        {
           _txtHealth.text = currentHealth + " / " + maxHealth;
        }
    }
}