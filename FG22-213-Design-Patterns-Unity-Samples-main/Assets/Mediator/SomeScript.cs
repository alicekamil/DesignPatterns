using UnityEngine;

namespace Mediator
{
    public class SomeScript : MonoBehaviour
    {
        private object _something;
        private object _otherThing;

        void Awake()
        {
            this._something = new object();
            this._otherThing = GameManager.Instance.anotherScript._anotherThing;
            Debug.Log("Other Thing: "+this._otherThing);
        }
    }
}