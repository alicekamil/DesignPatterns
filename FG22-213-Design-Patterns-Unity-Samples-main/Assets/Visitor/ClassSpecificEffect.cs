using System;
using UnityEngine;

namespace Visitor
{
    public class ClassSpecificEffect : IVisitor
    {
        public void Visit(Druid druid)
        {
            druid.naturePower++;
            Debug.Log($"Increased {druid}'s Nature Power to {druid.naturePower}");
        }

        public void Visit(Mage mage)
        {
            mage.mana++;
            Debug.Log($"Increased {mage}'s Mana to {mage.mana}");
        }
    }
}