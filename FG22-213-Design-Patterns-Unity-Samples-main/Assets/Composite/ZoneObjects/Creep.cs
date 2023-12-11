using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Composite
{
    public class Creep : MonoBehaviour, IAITarget
    {
        public float health;
        public bool friendly;
        
        # region IAITarget

        string IAITarget.Name => this.ToString();
        int IAITarget.Health => Mathf.CeilToInt(health);
        string IAITarget.AssociatedClan => default;
        bool IAITarget.Attackable => !friendly;
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