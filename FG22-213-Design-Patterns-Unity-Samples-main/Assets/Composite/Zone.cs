using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Composite
{
    /// <summary>
    /// IEnumerable
    /// yield
    /// Extension Methods
    /// LINQ
    /// </summary>
    public class Zone : MonoBehaviour, IEnumerable<IAITarget>
    {
        public static Zone Current { get; private set; }
        public Stack<Building> buildings;
        public Creep[] creeps;
        public Queue<Endboss> endbosses;
        public LinkedList<Player> players;
        public HashSet<Environment> environments;

        void Start()
        {
            Current = this;
            buildings = new Stack<Building>(FindObjectsOfType<Building>());
            creeps = FindObjectsOfType<Creep>().ToArray();
            endbosses = new Queue<Endboss>(FindObjectsOfType<Endboss>());
            players = new LinkedList<Player>(FindObjectsOfType<Player>());
        }
        
        public void Visit(IAITarget target)
        {
            Debug.Log($"Visiting {target}");
            foreach (var child in target.Children)
            {
                Visit(child);
            }
        }
        
        public IEnumerator<IAITarget> GetEnumerator()
        {
            foreach (var rootObject in GetRootObjects())
            {
                foreach (var target in rootObject)
                    yield return target;
            }
        }

        public IEnumerable<IAITarget> GetRootObjects()
        {
            foreach (var building in buildings) 
                yield return building;
            foreach (var creep in creeps) 
                yield return creep;
            foreach (var player in players) 
                yield return player;
            foreach (var endboss in endbosses) 
                yield return endboss;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}