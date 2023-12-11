using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Composite
{
    [Serializable]
    public class Weakpoint : IAITarget
    {
        public bool covered;
        public Vector3 offset;
        
        
        string IAITarget.Name => this.ToString();
        public int Health => 1;
        public string AssociatedClan { get; }
        public bool Attackable => !covered;
        public Vector3 Position { get; }
        public IEnumerable<IAITarget> Children => Array.Empty<IAITarget>();

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