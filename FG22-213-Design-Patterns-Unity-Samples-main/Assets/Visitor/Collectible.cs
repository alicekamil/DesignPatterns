using UnityEngine;

namespace Visitor
{
    public class Collectible : MonoBehaviour
    {
        private IVisitor effect = new ClassSpecificEffect();
        private void OnTriggerEnter(Collider other)
        {
            var visitedClass = other.GetComponent<IVisitable>();
            if (visitedClass == null) return;
            visitedClass.Accept(effect);
        }
    }
}