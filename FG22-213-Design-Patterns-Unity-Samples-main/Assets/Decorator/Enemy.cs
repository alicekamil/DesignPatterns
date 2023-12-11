using UnityEngine;

namespace Decorator
{
    public class Enemy : MonoBehaviour
    {
        public Player player;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.Health.ReduceHealth(1);
                if (player.Health.IsDead())
                {
                    Debug.Log("Haha, I win!");
                }
                else
                {
                    Debug.Log($"I see you still have {player.Health.CurrentHealth} Health left.");
                }
            }
        }
    }
}