using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Facade
{
    [Serializable]
    public struct KVP<A, B>
    {
        public A key;
        public B value;
    }
    
    [CreateAssetMenu]
    public class AudioLibrary : ScriptableObject
    {
        [field:SerializeField] KVP<SFXType, AudioClip>[] _keyValuePairs;

        private Dictionary<SFXType, AudioClip> _dictionary;        
        public Dictionary<SFXType, AudioClip> Dictionary
        {
            get
            {
                if (_dictionary == null)
                {
                    _dictionary = new Dictionary<SFXType, AudioClip>(_keyValuePairs.Select(it => new KeyValuePair<SFXType, AudioClip>(it.key, it.value)));
                }

                return _dictionary;
            }
        }
    }
}