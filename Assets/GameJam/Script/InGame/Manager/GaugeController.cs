using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Tech.C
{
    /// <summary>
    /// 各スライダーの管理と、UIの更新を行う
    /// </summary>
    public class GaugeController : Singleton<GaugeController>
    {

        [SerializeField] private Slider gambleSlider;
        [SerializeField] private Slider entertainmentSlider;

        private int gambleValue = 0;
        private int entertainmentValue = 0;

        private const int MAX_GAMBLE = 100;
        private const int MAX_ENTERTAINMENT = 100;
        protected override bool UseDontDestroyOnLoad => false;

        private void Update()
        {
            if (gambleSlider != null)
            {
                gambleSlider.maxValue = MAX_GAMBLE;
                gambleSlider.value = gambleValue;
            }
            if (entertainmentSlider != null)
            {
                entertainmentSlider.maxValue = MAX_ENTERTAINMENT;
                entertainmentSlider.value = entertainmentValue;
            }
        }

        public void AddGamble(int amount)
        {
            gambleValue = Mathf.Clamp(gambleValue + amount, 0, MAX_GAMBLE);
            if (gambleValue >= MAX_GAMBLE)
            {
                PlayerPrefs.SetString("lastPlayedScene", SceneManager.GetActiveScene().name);
                SceneController.I.LoadScene("BadEnd");
            }
        }

        public void AddEntertainment(int amount)
        {
            entertainmentValue = Mathf.Clamp(entertainmentValue + amount, 0, MAX_ENTERTAINMENT);
            if (entertainmentValue >= MAX_ENTERTAINMENT)
            {
                PlayerPrefs.SetString("lastPlayedScene", SceneManager.GetActiveScene().name);
                SceneController.I.LoadScene("GoodEnd");
            }
        }

    }
}
