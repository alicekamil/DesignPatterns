using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TemplateMethod
{
    /*
     * Coffee Recipe
     * - Boil water
     * - Brew coffee in boiling water
     * - Pour coffee in cup
     * - Add sugar and milk
     *
     * Tea Recipe
     * - Boil water
     * - Steep tea in boiling water
     * - Pour tea in cup
     * - Add lemon
     *
     *
     * brewing2: (CapuccinoBrewing)
     * -----> CapuccinoBrewing-VTABLE
     *
     *
     *
     * CapuccinoBrewing-VTABLE
     *   AddCondiments -> CapuccinoBrewing.AddCondiments()
     *   Brew -> BaseBrew.Brew()
     * 
     * 
     */

    public class EspressoHouse
    {
        void Foo()
        {
            CapuccinoBrewing brewing = new CapuccinoBrewing();
            
            // CapuccinoBrewing.AddCondiments(brewingObject);
            
           // optimized, because we know it's a CapuccinoBrewing and the method is sealed on that type. No v-table lookup.
            //brewing.AddCondiments();

            BaseBrewing brewing2 = new CapuccinoBrewing();
            
            // brewingObject.GetVTable().AddCondiments(brewingObject);
            
            // not optimized, because we don't know it's a CapuccinoBrewing and on BaseBrewing, AddCondiments is virtual
            //brewing2.AddCondiments();
        }
    }

    public interface IValidator
    {
        bool Validate(Purchase purchase);
    }

    public class CurrencyValidator : IValidator
    {
        public int Priority => 100;


        public bool Validate(Purchase purchase)
        {
            throw new System.NotImplementedException();
        }
    }

    public class Main
    {
        public Stack<GameObject> popups;


        void OnAndroidBackButton()
        {
            foreach (var popup in popups)
            {
            }
        }
    }

    public class Purchase
    {
        
        
    }

    public abstract class BaseBrewing
    {
        void BoilWater()
        {
            
        }
        
        public void Start()
        {
            BoilWater();
            Brew();
            PourInCup();
            AddCondiments();
        }

        protected abstract void Brew();

        protected abstract void AddCondiments();

        void PourInCup()
        {
            
        }
    }
    
    public class CoffeeBrewing : BaseBrewing
    {
        protected override void Brew()
        {
            Debug.Log("Brewing Coffee in Hot Water.");
        }

        protected override void AddCondiments()
        {
            Debug.Log("Adding Sugar and Milk.");
        }
    }
    
    public sealed class TeaMaking : BaseBrewing
    {
        protected override void Brew()
        {
            Debug.Log("Steeping Tea in Hot Water.");
        }

        protected override void AddCondiments()
        {
            Debug.Log("Adding Lemon.");
        }
    }
    
    // Animal
    //   - bool hungry
    
    // Bird : Animal
    // Horse : Animal
    
    // public class Pegasus : Bird, Horse

    // public class ChaiTeaMaking : TeaMaking
    // {
    //     
    // }

    public class CoolImage : Animator
    {
        
    }

    public class CoolButton : Button
    {
        
    }
    
    
    
    
    
    
    
    
    
    
    public class HotWaterBrewing : BaseBrewing {
        protected override void Brew()
        {
        }

        protected override void AddCondiments()
        {
        }
    }
    
    
    
    public class CapuccinoBrewing : BaseBrewing {
        protected override void Brew()
        {
            throw new System.NotImplementedException();
        }

        protected sealed override void AddCondiments()
        {
        }
    }
    
}