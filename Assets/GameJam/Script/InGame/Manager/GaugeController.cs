using UnityEngine;
using UnityEngine.UI;

namespace Tech.C
{
    /// <summary>
    /// 各スライダーの管理と、UIの更新を行う
    /// </summary>
    public class GaugeController : MonoBehaviour
    {
        // スライダーUI
        [SerializeField] private Slider gambleSlider;
        [SerializeField] private Slider entertainmentSlider;
        [SerializeField] private Slider moneySlider;

        // 現在値
        private int gambleValue = 0;
        private int entertainmentValue = 0;
        private int moneyValue = 100;

        // 最大値
        private const int MAX_GAMBLE = 100;
        private const int MAX_ENTERTAINMENT = 100;
        private const int MAX_MONEY = 100;

        private void Update()
        {
            UpdateSliders();
        }

        // --- 増減メソッド ---

        public void AddGamble(int amount)
        {
            gambleValue = Mathf.Clamp(gambleValue + amount, 0, MAX_GAMBLE);
        }

        public void SubtractGamble(int amount)
        {
            gambleValue = Mathf.Clamp(gambleValue - amount, 0, MAX_GAMBLE);
        }

        public void AddEntertainment(int amount)
        {
            entertainmentValue = Mathf.Clamp(entertainmentValue + amount, 0, MAX_ENTERTAINMENT);
        }

        public void Subtractentertainment(int amount)
        {
            entertainmentValue = Mathf.Clamp(entertainmentValue - amount, 0, MAX_ENTERTAINMENT);
        }

        public void AddMoney(int amount)
        {
            moneyValue = Mathf.Clamp(moneyValue + amount, 0, MAX_MONEY);
        }

        public void SubtractMoney(int amount)
        {
            moneyValue = Mathf.Clamp(moneyValue - amount, 0, MAX_MONEY);
        }

        // --- Sliderを更新するメソッド ---
        private void UpdateSliders()
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

            if (moneySlider != null)
            {
                moneySlider.maxValue = MAX_MONEY;
                moneySlider.value = moneyValue;
            }
        }

    }
}
