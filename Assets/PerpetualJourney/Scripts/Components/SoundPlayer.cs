using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerpetualJourney
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundPlayer : MonoBehaviour
    {
        [SerializeField]private AudioSource _musicPlayer;
        [SerializeField]private AudioSource _stepSoundPlayer;
        [SerializeField]private SoundList _soundList;

        public static SoundPlayer Instance;

        private AudioSource _audioSource;

        public enum AudioEnum
        {
            Click,
            Horn,
            Shatter,
            Swallow,
            Jump,
            land
        }
        
        public void InitializeAudioPlayer()
        {
            Instance = this;
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayAudio(AudioEnum enumValue)
        {
            if(GetAudioClip(enumValue, out AudioClip clip))
            {
                _audioSource.PlayOneShot(clip);
            }
        }

        public bool GetAudioClip(AudioEnum enumValue, out AudioClip clip)
        {
             if((int)enumValue < _soundList.AudioClips.Count)
            {
                clip = _soundList.AudioClips[(int)enumValue];
                if(clip != null)
                return true;
            }

            clip = null;
            return false;
        }

        public void PlayRandomStep()
        {
            int rndIndex = Random.Range(0, _soundList.Playersteps.Count);
            _stepSoundPlayer.PlayOneShot(_soundList.Playersteps[rndIndex]);
        }

        public void SetMusicMenu()
        {
            StopMusic();
            _musicPlayer.clip = _soundList.Musics[0];
            _musicPlayer.Play();
        }
        
        public void SetMusicGame()
        {
            StopMusic();
            _musicPlayer.clip = _soundList.Musics[1];
            _musicPlayer.Play();
        }

        public void StopMusic()
        {
            _musicPlayer.Stop();
        }

        private void Awake()
        {
            InitializeAudioPlayer();
        }
    }
}
