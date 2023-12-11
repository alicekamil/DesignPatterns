using UnityEngine;

namespace TypeObject
{
    public class ResourceLookup : ScriptableObject
    {
        public static ResourceLookup Instance;
        public ResourceType gold;
        public ResourceType wood;
    }
    
    [CreateAssetMenu]
    public class ResourceType : ScriptableObject
    {
        public Sprite sprite;
        public string localizationKey;
        public string descriptionKey;
        public Color color;
    }
}