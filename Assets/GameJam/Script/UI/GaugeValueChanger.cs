using UnityEngine;
using UnityEngine.UI;

public class GaugeValueChanger : MonoBehaviour
{
    [SerializeField] private Slider gaugeSlider;
    [SerializeField] private Image fillImage;

    void Start()
    {
        if (gaugeSlider != null)
        {
            gaugeSlider.onValueChanged.AddListener(OnValueChanged);
        }
    }

    // スライダーの値が変更されたときに実行されるメソッド
    public void OnValueChanged(float value)
    {
        // ゲージの値が0の時
        if (value == 0)
        {
            // fillImage（塗りつぶし部分）の色を完全に透明にする
            // new Color(R, G, B, A) のA（アルファ値）を0にする
            fillImage.color = new Color(fillImage.color.r, fillImage.color.g, fillImage.color.b, 0f);
        }
        else
        {
            // ゲージの値が0以外の時
            // fillImageの色を元の不透明な色に戻す
            // new Color(R, G, B, A) のA（アルファ値）を1にする
            fillImage.color = new Color(fillImage.color.r, fillImage.color.g, fillImage.color.b, 1f);
        }
    }
}
