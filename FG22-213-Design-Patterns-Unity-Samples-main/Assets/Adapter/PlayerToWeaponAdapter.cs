using UnityEngine;

namespace Adapter
{
    public class PlayerToWeaponAdapter : IWeapon // Display Port Output
    {
        private Player _player;

        public PlayerToWeaponAdapter(Player player) // HDMI Input
        {
            _player = player;
        }
        public void PullTrigger(Material material)
        {
            _player.weapon.PullTrigger(material);
        }
    }
}