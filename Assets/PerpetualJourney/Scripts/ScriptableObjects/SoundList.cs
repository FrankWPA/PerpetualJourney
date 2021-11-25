using System;
using System.Collections.Generic;
using UnityEngine;

namespace PerpetualJourney
{
    [CreateAssetMenu(fileName = "SoundList", menuName = "PerpetualJourney/Sound List")]
    public class SoundList : ScriptableObject
    {
        [EnumNamedArray(typeof(SoundPlayer.AudioEnum))]
        public List<AudioClip> AudioClips;
        
        public List<AudioClip> Playersteps;
        public List<AudioClip> Musics;
    }
}
