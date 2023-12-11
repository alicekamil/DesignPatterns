using System;
using UnityEngine;

namespace Decorator
{
    public interface IArmor
    {
        int CurrentArmor { get; }
    }
    
    public class ArmorHealthDecorator : IHealth, IArmor
    {

        private IHealth _health;

        public ArmorHealthDecorator(IHealth health, int initialArmor)
        {
            _health = health;
            CurrentArmor = initialArmor;
        }

        public int CurrentHealth => _health.CurrentHealth; // adding the armor to the current health
        public int CurrentArmor { get; private set; }
        
        public void IncreaseHealth(int amount)
            => _health.IncreaseHealth(amount);

        public void ReduceHealth(int amount)
        {
            int armorToReduce = Math.Min(amount, CurrentArmor);
            Debug.Log($"Armor has {CurrentArmor} left. Reducing Damage by {armorToReduce}.");
            CurrentArmor -= armorToReduce;
            amount -= armorToReduce;
            _health.ReduceHealth(amount);
        }

        public bool IsDead()
            => _health.IsDead();

    }
    
    public class ArmorPowerup : MonoBehaviour
    {
        public Player player;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("Decorating the player with 3 Armor.");
                player.Health = new ArmorHealthDecorator(player.Health, 3);
            }
        }
    }
}