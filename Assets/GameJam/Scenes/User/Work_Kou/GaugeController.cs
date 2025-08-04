using UnityEngine;
using UnityEngine.UI;

namespace Tech.C
{

    public class GaugeController : MonoBehaviour
    {

        // スライダーUI
        public Slider gambleSlider;
        public Slider funSlider;
        public Slider moneySlider;

        // 現在値
        private int gambleValue = 0;
        private int funValue = 0;
        private int moneyValue = 100;

        // 最大値
        public int maxGamble = 100;
        public int maxFun = 100;
        public int maxMoney = 100;

        // 増加量（任意）
        public int addGamble = 10;
        public int addFun = 5;
        public int addMoney = 20;

        /* テスト用 */
        [ContextMenu("１０点ギャンブル追加")]
        public void AddGambleTest()
        {
            AddGamble(10);
        }

        private void Update()
        {
            UpdateSliders();
        }

        // --- 増減メソッド ---

        public void AddGamble(int amount)
        {
            gambleValue = Mathf.Clamp(gambleValue + amount, 0, maxGamble);
        }

        public void SubtractGamble(int amount)
        {
            gambleValue = Mathf.Clamp(gambleValue - amount, 0, maxGamble);
        }

        public void AddFun(int amount)
        {
            funValue = Mathf.Clamp(funValue + amount, 0, maxFun);
        }

        public void SubtractFun(int amount)
        {
            funValue = Mathf.Clamp(funValue - amount, 0, maxFun);
        }

        public void AddMoney(int amount)
        {
            moneyValue = Mathf.Clamp(moneyValue + amount, 0, maxMoney);
        }

        public void SubtractMoney(int amount)
        {
            moneyValue = Mathf.Clamp(moneyValue - amount, 0, maxMoney);
        }

        // --- Sliderを更新するメソッド ---
        private void UpdateSliders()
        {
            if (gambleSlider != null)
            {
                gambleSlider.maxValue = maxGamble;
                gambleSlider.value = gambleValue;
            }

            if (funSlider != null)
            {
                funSlider.maxValue = maxFun;
                funSlider.value = funValue;
            }

            if (moneySlider != null)
            {
                moneySlider.maxValue = maxMoney;
                moneySlider.value = moneyValue;
            }
        }

    }
}
