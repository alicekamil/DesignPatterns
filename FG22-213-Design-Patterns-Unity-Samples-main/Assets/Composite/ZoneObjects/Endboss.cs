using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Composite
{
    public class Endboss : MonoBehaviour, IAITarget
    {
        public Weakpoint[] weakpoints;
        
        string IAITarget.Name => this.ToString();
        public int Health => weakpoints.Length;
        public string AssociatedClan => default;
        public bool Attackable => true;
        public Vector3 Position => transform.position;
        public IEnumerable<IAITarget> Children => weakpoints;

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