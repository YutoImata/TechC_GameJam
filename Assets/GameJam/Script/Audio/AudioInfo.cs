using UnityEngine;
using System;

namespace Tech.C
{
    public enum AudioType { BGM, SE }

    [Serializable]
    public class AudioInfo
    {
        public string name;
        public AudioType type;
        public AudioClip audioClip;
        [Range(0f, 1f)] public float volume = 1f;
    }
}