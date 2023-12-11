using System;
using System.Collections.Generic;
using UnityEngine;

namespace TypeObject
{
    
    // ResourceType.Gold => 0x000AF0000
    // ResourceType.Wood => 0x000AF0008
    public static class ResourceManager
    {
        private static Dictionary<string, ResourceType> _resourceTypes = new();
        public static ResourceType Get(string resourceTypeId)
        {
            if (!_resourceTypes.TryGetValue(resourceTypeId, out var resourceType))
            {
                resourceType = new ResourceType();
                _resourceTypes[resourceTypeId] = resourceType;
            }

            return resourceType;
        }
    }
    
    // Type Object

    [Serializable]
    // Typed Object
    public class Resource
    {
        public ResourceType type;
        public int amount;
    }
}