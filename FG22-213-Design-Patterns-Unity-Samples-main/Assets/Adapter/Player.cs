using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Adapter
{
    public static class Singletons
    {
        public static IAnalytics analytics = new NoAnalytics();
    }
    
    public interface IAnalytics
    {
        void Track(string eventName);
    }

    public class NoAnalytics : IAnalytics
    {
        public void Track(string eventName)
        {
        }
    }
    
    public class PlayerController{
        void Update()
        {
            Singletons.analytics.Track("HelloWorld");
        }
    }
    
    public interface IPlayerInput
    {
        bool TurnLeft();
    }

    public class PlayerTouchInput : IPlayerInput
    {
        public bool TurnLeft()
        {
            if (Input.touchCount == 0) return false;
            return Input.GetTouch(0).deltaPosition.x < 0f;
        }
    }

    public static class IronSourceSDK
    {
        public static Dictionary<int, int> a;
        public static void Track(string eventName)
        {
        }
    }
    


    public class SaveSystem
    {
        public void Save(string key, string value) 
            => PlayerPrefs.SetString(key, value);
        
        public string Load(string key) 
            => PlayerPrefs.GetString(key);
    }

    public enum EventType
    {
        GameStart,
        PlayerDeath,
        LevelWin
    }

    public interface ITracking
    {
        void Track(EventType eventType);
    }
    
    public class IronSourceAdapter : ITracking
    {
        public void Track(EventType eventType)
        {
            IronSourceSDK.Track(eventType.ToString());
        }
    }
    

    public class PlayerKeyboardInput : IPlayerInput
    {
        public bool TurnLeft()
        {
            return Input.GetKeyDown(KeyCode.A);
        }
    }

    public interface IDataLoader
    {
        T Load<T>(string path);
    }

    public class ObjectFromJsonFileLoader : IDataLoader
    {
        public T Load<T>(string path)
        {
            if (!File.Exists(path)) return default;
            var text = File.ReadAllText(path);
            return JsonUtility.FromJson<T>(text);
        }
    }

    public interface IVillage
    {
        IEnumerable<IReadOnlyBuilding> Buildings { get; }
        bool TryAddBuilding(Building building);
    }


    public interface IReadOnlyBuilding
    {
        string Name { get; }
    }

    public class Building : IReadOnlyBuilding
    {
        public string Name { get; set; }
    }
    
    public class Village : IVillage
    {
        List<Building> _buildings;
        public IEnumerable<IReadOnlyBuilding> Buildings => _buildings;
        
        public bool TryAddBuilding(Building building)
        {
            // validate input
            // then execute changes
            return true;// or false
        }
    }

    public class Guest
    {
        public Guest(Village village)
        {
            // restricted access to buildings
        }
    }
    
    public class AIPlayerInput : IPlayerInput
    {
        public bool TurnLeft()
        {
            // evaluate whether we want to turn left
            // is so, return true:
            return true;
        }
    }
    
    public class Player : MonoBehaviour
    {
        public KeyCode[] movement;
        [SerializeReference] public IWeapon weapon;
        
        void Update()
        {
            if (Input.GetKey(movement[0]))
            {
                transform.Translate(Vector3.up * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(movement[1]))
            {
                transform.Translate(Vector3.down * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(movement[2]))
            {
                transform.Translate(Vector3.left * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(movement[3]))
            {
                transform.Translate(Vector3.right * Time.deltaTime, Space.World);
            }
            if (Input.GetKeyDown(movement[4]))
            {
                Attack();
            }
            
            if (Input.GetKeyDown(movement[5]))
            {
                foreach (var player in FindObjectsOfType<Player>())
                {
                    if (player == this) continue;
                    if (Vector3.Distance(player.transform.position, transform.position) > 2) continue;
                    // pick up the player:
                    player.transform.SetParent(transform);
                    this.weapon = new PlayerToWeaponAdapter(player);
                    break;
                }
            }
            
        }

        public void Attack()
        {
            this.weapon?.PullTrigger(GetComponent<Renderer>().material);
        }
    }
}