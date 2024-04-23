using DG.Tweening;
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
            _slider.DOValue(amount, 0.5f);
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