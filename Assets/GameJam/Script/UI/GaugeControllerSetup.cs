using UnityEngine;
using UnityEngine.UI;
using Tech.C;

/// <summary>
/// 各シーンでGaugeControllerにSlider参照を設定するためのスクリプト
/// シーン内のCanvasまたは適当なGameObjectにアタッチして、Inspector でSliderを設定する
/// </summary>
public class GaugeControllerSetup : MonoBehaviour
{
    [Header("このシーンのSlider参照")]
    [SerializeField] private Slider gambleSlider;
    [SerializeField] private Slider entertainmentSlider;

    private void Start()
    {
        // GaugeControllerにSlider参照を設定
        if (GaugeController.I != null)
        {
            GaugeController.I.SetSliders(gambleSlider, entertainmentSlider);
        }
    }
}
