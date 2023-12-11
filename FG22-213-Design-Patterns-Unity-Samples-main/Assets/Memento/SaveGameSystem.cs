using UnityEngine;

namespace Memento
{
    // Caretaker
    public class SaveGameSystem : MonoBehaviour
    {
        [ContextMenu("Save")]
        public void Save()
        {
            // Originator
            var player = FindObjectOfType<Player>();
            
            // Memento
            var memento = player.Save();
            
            // Serialize
            var json = JsonUtility.ToJson(memento);
            PlayerPrefs.SetString("PlayerMemento", json);

            // No Memento
        }

        [ContextMenu("Load")]
        public void Load()
        {
            var json = PlayerPrefs.GetString("PlayerMemento", "{}");
            
            // Memento
            var memento = JsonUtility.FromJson<PlayerMemento>(json);
            
            // Originator
            var player = FindObjectOfType<Player>();
            player.Restore(memento);
        }
    }
}