using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Composite
{
    public class Item : MonoBehaviour, IAITarget
    {
        public int health;
        public bool immune;
        public Player player;
        
        # region IAITarget

        string IAITarget.Name => this.ToString();
        int IAITarget.Health => health;
        string IAITarget.AssociatedClan => player?.clan;
        bool IAITarget.Attackable => !immune;
        Vector3 IAITarget.Position => transform.position;
        public IEnumerable<IAITarget> Children => Array.Empty<IAITarget>();

        #endregion // IAITarget

        public IEnumerator<IAITarget> GetEnumerator()
        {
            yield return this;
            foreach (var child in Children)
            {
                yield return child;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}