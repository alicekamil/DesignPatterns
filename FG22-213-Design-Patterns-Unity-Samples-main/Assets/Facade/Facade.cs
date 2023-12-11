using System.Linq;
using UnityEngine;

namespace Facade
{
    public enum SFXType
    {
        Jump,
        Step,
        Click,
        Drag,
        Drop
    }
    
    
    
    
    
    
    public interface ISFXPlayer
    {
        void PlaySFX(SFXType sfxType);
    }




    public class ConfiguredAudioClip : ScriptableObject
    {
        public SFXType sfxType;
        public AudioClip[] audioClips;
        public float randomizedPitchMin;
        public float randomizedPitchMax;
    }

    public class BetterSFXPlayer : ISFXPlayer
    {

        public void PlaySFX(SFXType sfxType)
        {
            // generate random pitch
            // generate random location
            // assign it to audio mixer's SFX Channel
            // load the correct resources
        }
    }
    
    public class AudioClipSFXPlayer : ISFXPlayer
    {
        public AudioLibrary libray;
        public AudioClipSFXPlayer()
        {
            libray = Resources.Load<AudioLibrary>("Path/To/MainAudioLibrary");
        }
        
        public void PlaySFX(SFXType sfxType)
        {
            AudioSource.PlayClipAtPoint(libray.Dictionary[sfxType], Camera.main.transform.position);
        }
    }
    
    public class Player : MonoBehaviour
    {
        public AudioClip jumpSfx;
        private AudioSource _audioSource;
        private ISFXPlayer _sfxPlayer;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // jump
                _sfxPlayer.PlaySFX(SFXType.Jump);
            }
        }
    }
}