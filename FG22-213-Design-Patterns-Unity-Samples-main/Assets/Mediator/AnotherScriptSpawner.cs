using UnityEngine;

namespace Mediator
{
    public class AnotherScriptSpawner : MonoBehaviour
    {
        void Awake()
        {
            Debug.Log("Spawning another script.");
            var anotherScriptGO = new GameObject("AnotherScript");
            GameManager.Instance.anotherScript = 
                anotherScriptGO.AddComponent<AnotherScript>();
        }
    }
}