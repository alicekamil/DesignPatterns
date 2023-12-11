using System;
using UnityEngine;

namespace Memento
{
    [Serializable]
    public struct PlayerMemento
    {
        public int health;
        public int strength;
        public string name;
        public Vector3 position;

        public PlayerMemento(int health, int strength, string name, Vector3 position)
        {
            this.health = health;
            this.strength = strength;
            this.name = name;
            this.position = position;
        }
    }
    
    public class Player : MonoBehaviour
    {
        
        public int health;
        public int strength;
        public string name;

        public PlayerMemento Save()
        {
            return new PlayerMemento(health, strength, name, transform.position);
        }

        public void Restore(PlayerMemento memento)
        {
            health = memento.health;
            strength = memento.strength;
            name = memento.name;
            transform.position = memento.position;
        }
    }
    
    // Newtonsoft Json.net
}