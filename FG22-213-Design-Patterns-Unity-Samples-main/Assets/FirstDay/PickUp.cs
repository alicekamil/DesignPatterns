using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class SpawnPoint : MonoBehaviour
    {
        public virtual bool IsUnlocked()
        {
            return true;
        }
    }

    public class PlayerSpawner
    {
        public void Start()
        {
            var spawnPoints = Resources.FindObjectsOfTypeAll<SpawnPoint>()
                .Where(it => it.IsUnlocked()).ToArray();
            var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        }
    }
    
    public abstract class PickUp : MonoBehaviour
    {
        public Action<GameObject> onPickup;
        public UnityEvent<GameObject> onPickup2;
        private Effect[] cachedEffects;
        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            if (!EditorApplication.isPlaying) return;
            if (!other.gameObject.TryGetComponent<HumanCharacterMovement>(out var pc)) return;

            // side effects !
            cachedEffects ??= gameObject.GetComponents<Effect>();

            foreach (var effect in cachedEffects)
            {
                //effect.Trigger();
            }
        }

        void OnEnable()
        {
            StartCoroutine(Co_UpdateTime());
        }

        IEnumerator Co_UpdateTime()
        {
            while (true)
            {
                // update time label
                yield return null;
            }
        }

        protected abstract void PickUpEffect(GameObject actor);
    }
}