using UnityEngine;

namespace Mediator
{
    public class AnotherScript : MonoBehaviour
    {
        public object _anotherThing;

        void Awake()
        {
            Debug.Log("Initializing another script.");
            this._anotherThing = new object();
        }
    }
}