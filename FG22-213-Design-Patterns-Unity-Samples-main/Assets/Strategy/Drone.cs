using System;
using UnityEngine;

namespace Strategy
{
    public class Drone : MonoBehaviour
    {
        public IMovementStrategy _movementStrategy;

        void Update()
        {
            transform.Translate(_movementStrategy.GetDirectionForTime(Time.time) * Time.deltaTime);

            if (Time.time > 10)
            {
                _movementStrategy = ScriptableObject.CreateInstance<ImmovableStrategy>();
            }
        }


        void Attack()
        {
            
        }

        void Defense()
        {
            
        }

        void Repair()
        {
            
        }
    }
}