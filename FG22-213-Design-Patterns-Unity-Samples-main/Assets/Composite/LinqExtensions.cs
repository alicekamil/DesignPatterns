using System;
using System.Collections.Generic;
using System.Linq;

namespace Composite
{
    public static class LinqExtensions
    {
        // generic          // extension method
        public static TSource MinBy<TSource, TComp>(this IEnumerable<TSource> collection, Func<TSource, TComp> func) where TComp : IComparable<TComp>
        {                  // delegate                 // generic constraints
            var closestTarget = collection.First();
            TComp closestDistance = func(closestTarget);
            
            foreach (var target in collection)
            {
                var newDistance = func(target);
                if (newDistance.CompareTo(closestDistance) < 0)
                {
                    closestDistance = newDistance;
                    closestTarget = target;
                }
            }

            return closestTarget;
        }
    }
}