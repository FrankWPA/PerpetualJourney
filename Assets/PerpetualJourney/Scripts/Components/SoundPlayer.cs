using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerpetualJourney
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundPlayer : MonoBehaviour
    {
        [SerializeField]private AudioSource _musicPlayer;
        [SerializeField]private SoundList _soundList;

        public static SoundPlayer Instance;

        private AudioSource _audioSource;

        public enum AudioEnum
        {
            Click,
            Horn,
            Shatter,
            Swallow,
            land,
            Jump
        }
        
        public void InitializeAudioPlayer()
        {
            Instance = this;
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayAudio(AudioEnum enumValue)
        {
            _audioSource.PlayOneShot(_soundList.AudioClips[(int)enumValue]);
        }

        public void PlayRandomStep()
        {
            int rndIndex = Random.Range(0, _soundList.Playersteps.Count);
            _audioSource.PlayOneShot(_soundList.Playersteps[rndIndex]);
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
