using UnityEngine;

namespace Tech.C
{
    public class AudioManager : Singleton<AudioManager>
    {
        [Tooltip("効果音・BGM再生用のAudioSource")]
        [SerializeField] private AudioSource audioSource;

        [Tooltip("管理するAudioData")]
        [SerializeField] private AudioData audioData;

        protected override void Init()
        {
            base.Init();
            if (audioSource == null)
            {
                Debug.LogError("AudioSourceをアタッチしてください");
            }
            if (audioData == null)
            {
                Debug.LogError("AudioDataがアタッチされていません");
            }
        }

        /// <summary>
        /// 音を再生する
        /// </summary>
        public void PlaySound(string name)
        {
            var element = audioData.elements.Find(e => e.name == name);
            audioSource.PlayOneShot(element.audioClip, element.volume);
        }
    }
}