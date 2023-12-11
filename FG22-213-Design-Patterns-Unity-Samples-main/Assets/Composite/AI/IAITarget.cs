using System.Collections.Generic;
using UnityEngine;

namespace Composite
{
    public interface IAITarget : IEnumerable<IAITarget>
    {
        string Name { get; }
        int Health { get; }
        string AssociatedClan { get; }
        bool Attackable { get; }
        Vector3 Position { get; }
        
        IEnumerable<IAITarget> Children { get; }
    }
}