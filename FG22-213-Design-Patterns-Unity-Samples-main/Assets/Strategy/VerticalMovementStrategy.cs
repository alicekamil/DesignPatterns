using UnityEngine;

namespace Strategy
{
    [CreateAssetMenu]
    public class VerticalMovementStrategy : IMovementStrategy
    {
        public override Vector3 GetDirectionForTime(float time)
            => time % 6 < 3 ? Vector3.up : Vector3.down;
    }
}