using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Composite
{
    public class Player : MonoBehaviour, IAITarget
    {
        public int health;
        public int bonusHealth;
        public string clan;
        
        // DANGER HERE: THE AI CAN'T IDENTIFY ITSELF!!
        # region IAITarget

        string IAITarget.Name => this.ToString();
        int IAITarget.Health => health;
        string IAITarget.AssociatedClan => clan;
        bool IAITarget.Attackable => true;
        Vector3 IAITarget.Position => transform.position;
        public IEnumerable<IAITarget> Children => Array.Empty<IAITarget>();

        public IEnumerator<IAITarget> GetEnumerator()
        {
            yield return this;
            foreach (var child in Children)
            {
                yield return child;
            }
        }

        #endregion // IAITarget

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}