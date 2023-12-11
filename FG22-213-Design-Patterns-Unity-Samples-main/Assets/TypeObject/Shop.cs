using System;
using UnityEngine;

namespace TypeObject
{
    public class ShopSpawner : MonoBehaviour
    {
        public ResourceType costsType;
        private void Awake()
        {
            var shop = new GameObject("Shop").AddComponent<Shop>();
            shop.Costs.type = costsType;
        }
    }
    
    public class Shop : MonoBehaviour
    {
        public Resource Costs;
        public Player player;

        [ContextMenu("Buy")]
        public void Buy()
        {
            if (player.Spend(this.Costs))
            {
                Debug.Log("Congrats, you got a new Item!");
            }
            else
            {
                Debug.Log("That's too pricey for you!");
            }
        }
    }
}