using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace Composite
{
    
    
    // We had a problem of chaotic code with many different object types in many different collections (Stack<Building>, Queue<Player>, ...)
    // We introduced a common interface that suffices our needs (Adapter, IAITarget)
    // We introduced the Iterator pattern to allow easy iteration over of all these collections (IEnumerable,IAITarget)
    // We used the yield keyword to make the implementation easier
    // We used LINQ to simplify the filtering logic (Where)
    // We wrote the MinBy-Algorithm as an extension method similar to LINQ Methods
    
    
    public interface IClanMember {
        public string Clan { get; }
    }
    
    // attack buildings owned not by players of our clan if they are not immune
    // attack creeps if they're not friendly
    // attack endbosses' weakpoints, but not environment's weakpoints
    // attack players from other clans
            
    // we want to attack the closest of these

    public class AI : MonoBehaviour
    {
        [FormerlySerializedAs("_player")] [SerializeField] private Player _selfPlayer;
        public IAITarget target;
        public void Update()
        {
            if (target == null)
            {
                target = PickTarget();
                Debug.Log($"Selected Target:{target.Name}");
            }
        }

        IAITarget PickTarget()
        {
            var validTargets = GetValidTargets();
            foreach (var t in validTargets)
            {
                Debug.Log($"Valid Target: {t.Name}");
            }
            return GetValidTargets()
                .MinBy(it => Vector3.Distance(it.Position, transform.position));
        }

        IEnumerable<IAITarget> GetValidTargets()
        {
            var targetsFromAllClans = 
                from target in Zone.Current
                where target.Attackable
                where target.Health > 0
                select target;

            if (_selfPlayer.clan == null)
                return targetsFromAllClans;
            
            return 
                from target in targetsFromAllClans
                where target.AssociatedClan != _selfPlayer.clan
                select target;
        }
    }
}