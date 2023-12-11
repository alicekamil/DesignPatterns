using UnityEngine;

namespace TypeObject
{
    public class Player : MonoBehaviour
    {
        public Resource[] resources;

        public bool Spend(Resource costs)
        {
            foreach (var owned in resources)
            {
                if (owned.type == costs.type)
                {
                    if (owned.amount < costs.amount)
                        return false;
                    owned.amount -= costs.amount;
                    return true;
                }
            }
            return default;
        }
    }
}