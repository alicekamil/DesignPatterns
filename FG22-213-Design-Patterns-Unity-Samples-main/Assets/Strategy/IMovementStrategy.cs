using UnityEngine;

namespace Strategy
{
    public abstract class IMovementStrategy : ScriptableObject
    {
        public abstract Vector3 GetDirectionForTime(float time);
    }
}