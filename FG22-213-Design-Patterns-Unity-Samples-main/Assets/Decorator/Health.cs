using System.Collections.Generic;
using UnityEngine;

namespace Decorator
{
    public class HealthLogger : IHealth
    {
        private IHealth _health;

        public HealthLogger(IHealth health)
        {
            _health = health;
        }
        
        public int CurrentHealth { get; }
        public void IncreaseHealth(int amount)
        {
            Debug.Log("Increasing health by "+amount);
            _health.IncreaseHealth(amount);
        }

        public void ReduceHealth(int amount)
        {
            throw new System.NotImplementedException();
        }

        public bool IsDead()
        {
            throw new System.NotImplementedException();
        }
    }
    
    public class Health : IHealth
    {
        public Health(int value)
        {
            CurrentHealth = value;
        }
        public int CurrentHealth { get; private set; }
        public void IncreaseHealth(int amount)
            => CurrentHealth += amount;

        public void ReduceHealth(int amount)
        {
            CurrentHealth -= amount;
            Debug.Log($"Reduced health by {amount}");
        }

        public bool IsDead() => CurrentHealth <= 0;
    }
}