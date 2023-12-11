using UnityEngine;

namespace DefaultNamespace.Factory
{
    public class GameObject
    {
        private int position;
        public virtual GameObject Clone()
        {
            var clone = new GameObject();
            CopyValues(clone);
            return clone;
        }

        protected virtual void CopyValues(GameObject target)
        {
            target.position = this.position;
        }
    }
    
    public class Robot : GameObject
    {
        private int power;
        public override GameObject Clone()
        {
            var robot = new Robot();
            // let base class clone its values to the new object
            CopyValues(robot);
            robot.power = this.power;
            return robot;
        }
    }

    public class RobotSpawner
    {
        private Robot robotTemplate;

        public void Spawn()
        {
            var newRobot = robotTemplate.Clone();
            
            // foreach(member in that) newObject.SetField(fieldInfo, oldObject.GetField(fieldInfo));
        }
    }
    
    
    public class WeaponConfig : ScriptableObject
    {
        public int cooldown;
        public Sprite inventorySprite;
        public GameObject bulletPrefab;
    }

    public interface IBullet
    {
        // functions here
    }

    public interface IBulletFactory
    {
        IBullet Create(WeaponConfig weaponConfig, Transform weaponMuzzleTransform);
        
    }

    public class BubbleBulletFactory : IBulletFactory
    {
        public IBullet Create(WeaponConfig weaponConfig, Transform weaponMuzzleTransform)
        {
            return default;
        }
    }
    
    
    public class DummyBulletFactory : IBulletFactory
    {
        public IBullet Create(WeaponConfig weaponConfig, Transform weaponMuzzleTransform)
        {
            var bullet = UnityEngine.GameObject.CreatePrimitive(PrimitiveType.Capsule);
            bullet.transform.SetPositionAndRotation(weaponMuzzleTransform.position, weaponMuzzleTransform.rotation);
            return default;
        }
    }
    
    public class Weapon : MonoBehaviour
    {
        private int ammo; // if we have ammo
        private int remainingCooldown; // and the cooldown is not greater than 0
        public GameObject owner; // if owner is not stunned
        private WeaponConfig weaponConfig;
        private IBulletFactory _bulletFactory;
        
        public void Update()
        {
            var clone = Instantiate(this.gameObject);
            if (Input.GetMouseButtonDown(0))
            {
                Fire();
            }
        }

        private void Fire()
        {
            var bullet = _bulletFactory.Create(this.weaponConfig, this.transform);
        }
    }
}