using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerpetualJourney
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundPlayer : MonoBehaviour
    {
        [SerializeField]private List<AudioClip> _audioClips;
        [SerializeField]private List<AudioClip> _playersteps;
        private AudioSource _audioSource;

        public static SoundPlayer instance;
        public enum AudioEnum
        {
            Click,
            Horn,
            Shatter,
            Swallow,
            land,
            Jump
        }

        private void Awake()
        {
            instance = this;
            _audioSource = GetComponent<AudioSource>();
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
    }
}
