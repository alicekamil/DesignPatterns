using UnityEngine;

namespace Mediator
{
    public class GameManager : MonoBehaviour
    {
        // Loading Complexity: O(1)
        public AnotherScriptSpawner _anotherScriptSpawner;
        public SomeScript _someScript;
        // dependencies of other scripts funnelled through GM
        public AnotherScript anotherScript;
        
        public static GameManager Instance { get; private set; }
        
        void Awake()
        {
            // Loading Complexity: O(n) (Linear Search)
            // foreach(var c in go.components) if(c.GetType() == type) return c;
            // _anotherScriptSpawner = GetComponent<AnotherScriptSpawner>();
            Instance = this;
            // first initialize spawner
            _anotherScriptSpawner.gameObject.SetActive(true);
            
            // then initialize other things
            _someScript.gameObject.SetActive(true);
        }
    }
}