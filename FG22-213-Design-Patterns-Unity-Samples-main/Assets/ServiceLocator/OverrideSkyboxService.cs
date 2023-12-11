using UnityEngine;

namespace ServiceLocator
{
    public class OverrideSkyboxService : MonoBehaviour, ISkyboxService
    {
        public Color getSkyboxColor()
        {
            return Color.red;
        }
    }
}