using UnityEngine;
using System.Collections.Generic;

namespace Tech.C
{
    [CreateAssetMenu(menuName = "Tech.C/AudioData")]
    public class AudioData : ScriptableObject
    {
        [Tooltip("登録する音データのリスト")]
        public List<AudioInfo> elements = new List<AudioInfo>();

        public AudioInfo FindByName(string name)
        {
            return elements.Find(elements => elements.name == name);
        }
    }
}