using UnityEngine;

namespace Adapter
{
    public class Pistol : MonoBehaviour, IWeapon
    {
        public void PullTrigger(Material material)
        {
            var bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            bullet.transform.SetPositionAndRotation(transform.position, transform.rotation);
            var rb = bullet.AddComponent<Rigidbody>();
            rb.velocity = transform.up;
            bullet.GetComponent<Renderer>().material = material;
        }
    }
}