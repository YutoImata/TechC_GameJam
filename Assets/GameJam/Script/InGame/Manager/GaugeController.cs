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

        private void Start()
        {
            Debug.Log("GaugeController Start() called");
            // 初期化時にSliderの最大値と初期値を設定
            if (gambleSlider != null)
            {
                Debug.Log($"gambleSlider found: {gambleSlider.name}");
                gambleSlider.maxValue = MAX_GAMBLE;
                gambleSlider.value = 0;
                Debug.Log($"gambleSlider initialized - maxValue: {gambleSlider.maxValue}, value: {gambleSlider.value}");
            }
            else
            {
                Debug.LogError("gambleSlider is null in Start! Check Inspector assignment.");
            }
            
            if (entertainmentSlider != null)
            {
                Debug.Log($"entertainmentSlider found: {entertainmentSlider.name}");
                entertainmentSlider.maxValue = MAX_ENTERTAINMENT;
                entertainmentSlider.value = 0;
                Debug.Log($"entertainmentSlider initialized - maxValue: {entertainmentSlider.maxValue}, value: {entertainmentSlider.value}");
            }
            else
            {
                Debug.LogError("entertainmentSlider is null in Start! Check Inspector assignment.");
            }
        }

        private void UpdateGambleUI()
        {
            Debug.Log($"UpdateGambleUI called: gambleSlider is null = {gambleSlider == null}");
            if (gambleSlider != null)
            {
                Debug.Log($"Setting gambleSlider.value from {gambleSlider.value} to {gambleValue}");
                gambleSlider.value = gambleValue;
                Debug.Log($"gambleSlider.value after setting: {gambleSlider.value}");
            }
            else
            {
                Debug.LogError("gambleSlider is null! Check Inspector assignment.");
            }
        }

        private void UpdateEntertainmentUI()
        {
            Debug.Log($"UpdateEntertainmentUI called: entertainmentSlider is null = {entertainmentSlider == null}");
            if (entertainmentSlider != null)
            {
                Debug.Log($"Setting entertainmentSlider.value from {entertainmentSlider.value} to {entertainmentValue}");
                entertainmentSlider.value = entertainmentValue;
                Debug.Log($"entertainmentSlider.value after setting: {entertainmentSlider.value}");
            }
            else
            {
                Debug.LogError("entertainmentSlider is null! Check Inspector assignment.");
            }
        }

        public void AddGamble(int amount)
        {
            Debug.Log($"AddGamble called: amount={amount}, before={gambleValue}");
            gambleValue = Mathf.Clamp(gambleValue + amount, 0, MAX_GAMBLE);
            Debug.Log($"AddGamble after: gambleValue={gambleValue}");
            UpdateGambleUI(); // Sliderを即座に更新
            
            if (gambleValue >= MAX_GAMBLE)
            {
                PlayerPrefs.SetString("lastPlayedScene", SceneManager.GetActiveScene().name);
                SceneController.I.LoadScene("BadEnd");
            }
        }

        public void AddEntertainment(int amount)
        {
            Debug.Log($"AddEntertainment called: amount={amount}, before={entertainmentValue}");
            entertainmentValue = Mathf.Clamp(entertainmentValue + amount, 0, MAX_ENTERTAINMENT);
            Debug.Log($"AddEntertainment after: entertainmentValue={entertainmentValue}");
            UpdateEntertainmentUI(); // Sliderを即座に更新
            
            if (entertainmentValue >= MAX_ENTERTAINMENT)
            {
                PlayerPrefs.SetString("lastPlayedScene", SceneManager.GetActiveScene().name);
                SceneController.I.LoadScene("GoodEnd");
            }
        }

    }
}
