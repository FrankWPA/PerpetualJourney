using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerpetualJourney
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundPlayer : MonoBehaviour
    {
        [SerializeField]private AudioSource _musicPlayer;
        [SerializeField]private List<AudioClip> _audioClips;
        [SerializeField]private List<AudioClip> _playersteps;
        [SerializeField]private List<AudioClip> _musics;

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

        public void PlayAudioOnPosition(Vector3 position, AudioEnum enumValue)
        {
            AudioSource.PlayClipAtPoint(_audioClips[(int)enumValue], position);
        }

        public void PlayAudio(AudioEnum enumValue)
        {
            _audioSource.PlayOneShot(_audioClips[(int)enumValue]);
        }

        public void PlayRandomStep()
        {
            int rndIndex = Random.Range(0, _playersteps.Count);
            _audioSource.PlayOneShot(_playersteps[rndIndex]);
        }

        public void SetMusicMenu()
        {
            StopMusic();
            _musicPlayer.clip = _musics[0];
            _musicPlayer.Play();
        }
        
        public void SetMusicGame()
        {
            StopMusic();
            _musicPlayer.clip = _musics[1];
            _musicPlayer.Play();
        }

        public void StopMusic()
        {
            _musicPlayer.Stop();
        }

        private void Awake()
        {
            Instance = this;
            _audioSource = GetComponent<AudioSource>();
        }
    }
}
