using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Singleton
{
    public interface IGameManager
    {
        
    }   
    
    public class Dependencies
    {
        public Dictionary<Type, object> bindings;
        private Dependencies _instance;
        public Dependencies Instance => _instance;
        
        public IGameManager GameManager { get; }

        public T Get<T>()
        {
            return (T)bindings[typeof(T)];
        }
    }
    
    public class GameManager : MonoBehaviour, IGameManager
    {
        public static GameManager instance;

        public int timeLeft;
        
        private static GameManager _lazyInstance;
        public static GameManager LazyInstance
        {
            get
            {
                if (_lazyInstance == null)
                {
                    _lazyInstance = new GameObject("GameManager").AddComponent<GameManager>();
                }

                return _lazyInstance;
            }
        }
        void Start()
        {
            // no flow-control (when does the game manager start up / initialize? (lazy instantiation)
            // static access => risk of memory leaks
            // no decoupling, no access control (can be fixed)
            // huge problem with automated testing
               // unit tests need clean, default references
               // which are not affected by other unit tests
                  // which sometimes run at the same time (to run faster)
                  // testA: GameManager.instance.timeLeft = 2;
                  // testB: GameManager.instance.timeLeft = 100;
            
            if(instance != null)
                Destroy(this);
            else
                instance = this;
        }

        private void OnDestroy()
        {
            if (instance == this) instance = null;
        }
    }
}