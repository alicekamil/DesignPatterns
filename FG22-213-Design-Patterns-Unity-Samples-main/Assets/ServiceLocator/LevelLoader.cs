
using UnityEngine;

namespace ServiceLocator
{
    public class LevelLoader : MonoBehaviour
    {
        void Start()
        {
            var skyBoxService = ServiceLocator.GetSkyboxService();
            Camera.main.clearFlags = CameraClearFlags.Color;
            Camera.main.backgroundColor = skyBoxService.getSkyboxColor();
        }
    }
}