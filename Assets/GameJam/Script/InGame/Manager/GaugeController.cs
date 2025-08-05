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
                entertainmentSlider.value = 0;
            }
        }

        private void UpdateGambleUI()
        {
            Debug.Log($"UpdateGambleUI: gambleSlider={gambleSlider}, gambleValue={gambleValue}");
            if (gambleSlider != null)
            {
                gambleSlider.value = gambleValue;
                Debug.Log($"Slider更新完了: value={gambleSlider.value}");
            }
            else
            {
                Debug.LogError("gambleSlider が null です！");
            }
        }

        private void UpdateEntertainmentUI()
        {
            Debug.Log($"UpdateEntertainmentUI: entertainmentSlider={entertainmentSlider}, entertainmentValue={entertainmentValue}");
            if (entertainmentSlider != null)
            {
                entertainmentSlider.value = entertainmentValue;
                Debug.Log($"Slider更新完了: value={entertainmentSlider.value}");
            }
            else
            {
                Debug.LogError("entertainmentSlider が null です！");
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
