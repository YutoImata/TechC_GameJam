using UnityEngine;
using UnityEngine.UI;

public class Gauge : MonoBehaviour
{
    // Inspectorから設定できるようにPublicでSliderコンポーネントを定義
    public Slider gaugeSlider;

    // ゲージの塗りつぶし部分のImageコンポーネントを定義
    public Image fillImage;

    // Start関数でゲージの値が変わったときに呼び出されるメソッドを登録
    void Start()
    {
        // もしgaugeSliderが設定されていれば、イベントリスナーを追加
        if (gaugeSlider != null)
        {
            // スライダーの値が変更されたときにOnValueChangedメソッドを呼び出すように設定
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
