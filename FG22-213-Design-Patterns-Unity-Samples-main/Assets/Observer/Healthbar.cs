using UnityEngine;
using UnityEngine.UI;

namespace Observer
{
    public class Healthbar : MonoBehaviour
    {
        public Slider slider;

        void Start()
        {
            //FindObjectOfType<Health>().HealthChanged.AddListener(OnHealthChange);
        }

        void OnHealthChange(float newValue)
        {
            slider.value = newValue;
        }
    }
}