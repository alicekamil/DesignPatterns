using UnityEngine;

namespace Visitor
{
    public class Mage : MonoBehaviour, IVisitable
    {
        public int mana;
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}