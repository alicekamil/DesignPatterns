using UnityEngine;

namespace Strategy
{
    [CreateAssetMenu]
    public class ImmovableStrategy : IMovementStrategy
    {
        public override Vector3 GetDirectionForTime(float time)
            => Vector3.zero;
    }
}