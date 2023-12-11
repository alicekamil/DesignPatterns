using UnityEngine;

namespace Strategy
{
    [CreateAssetMenu]
    public class HorizontalMovementStrategy : IMovementStrategy
    {
        public float speed;
        public override Vector3 GetDirectionForTime(float time)
            => (time % 6 < 3 ? Vector3.right : Vector3.left) * speed;
    }
}