using UnityEngine;

namespace Decorator
{
    public interface IHealth
    {
        int CurrentHealth { get; }
        void IncreaseHealth(int amount);
        void ReduceHealth(int amount);
        bool IsDead();
    }
}