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
        [SerializeField] private Slider funSlider;
        [SerializeField] private Slider moneySlider;

        // 現在値
        private int gambleValue = 0;
        private int funValue = 0;
        private int moneyValue = 100;

        // 最大値
        private const int MAX_GAMBLE = 100;
        private const int MAX_FUN = 100;
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

        public void AddFun(int amount)
        {
            funValue = Mathf.Clamp(funValue + amount, 0, MAX_FUN);
        }

        public void SubtractFun(int amount)
        {
            funValue = Mathf.Clamp(funValue - amount, 0, MAX_FUN);
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

            if (funSlider != null)
            {
                funSlider.maxValue = MAX_FUN;
                funSlider.value = funValue;
            }

            if (moneySlider != null)
            {
                moneySlider.maxValue = MAX_MONEY;
                moneySlider.value = moneyValue;
            }
        }

    }
}
