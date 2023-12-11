using UnityEngine;

namespace ServiceLocator
{
    public class DefaultSkyboxService : ISkyboxService
    {
        public Color getSkyboxColor()
        {
            return Color.blue;
        }
    }
}