using System;
using UnityEngine;
using UnityEngine.Events;

namespace Observer
{
    public class Health : MonoBehaviour
    {
        public Action<string> HealthChanged;
        public float value = 10;

        [ContextMenu("TakeDamage")]
        void TakeDamage()
        {
            value--;
            HealthChanged += Console.WriteLine;
            HealthChanged?.Invoke(value.ToString());
        }
    }
}