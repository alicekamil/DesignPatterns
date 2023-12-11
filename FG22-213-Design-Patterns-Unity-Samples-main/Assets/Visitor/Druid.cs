using UnityEngine;

namespace Visitor
{
    public class Druid : MonoBehaviour, IVisitable
    {
        public int naturePower;
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}