using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

namespace Tech.C
{
    /// <summary>
    /// ボタンにマウスホバー時の拡大効果を提供するクラス
    /// </summary>
    public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [Header("ホバー効果設定")]
        [SerializeField] private float hoverScale = 1.1f; // ホバー時のスケール倍率
        [SerializeField] private float animationSpeed = 5f; // アニメーション速度
        
        private Vector3 originalScale; // 元のスケール
        private Vector3 targetScale; // 目標スケール
        private RectTransform rectTransform; // RectTransform参照
        private Coroutine scaleCoroutine; // スケールアニメーションコルーチン
        
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            originalScale = rectTransform.localScale;
            targetScale = originalScale;
        }
        
        /// <summary>
        /// マウスがボタンに入った時の処理
        /// </summary>
        public void OnPointerEnter(PointerEventData eventData)
        {
            targetScale = originalScale * hoverScale;
            
            if (scaleCoroutine != null)
            {
                StopCoroutine(scaleCoroutine);
            }
            
            scaleCoroutine = StartCoroutine(ScaleAnimation());
        }
        
        /// <summary>
        /// マウスがボタンから出た時の処理
        /// </summary>
        public void OnPointerExit(PointerEventData eventData)
        {
            targetScale = originalScale;
            
            if (scaleCoroutine != null)
            {
                StopCoroutine(scaleCoroutine);
            }
            
            scaleCoroutine = StartCoroutine(ScaleAnimation());
        }
        
        /// <summary>
        /// スケールアニメーションのコルーチン
        /// </summary>
        private IEnumerator ScaleAnimation()
        {
            while (Vector3.Distance(rectTransform.localScale, targetScale) > 0.01f)
            {
                rectTransform.localScale = Vector3.Lerp(
                    rectTransform.localScale, 
                    targetScale, 
                    animationSpeed * Time.unscaledDeltaTime // ポーズ中でも動作
                );
                
                yield return null;
            }
            
            rectTransform.localScale = targetScale;
            scaleCoroutine = null;
        }
        
        /// <summary>
        /// ホバー効果をリセット（元のサイズに即座に戻す）
        /// </summary>
        public void ResetScale()
        {
            if (scaleCoroutine != null)
            {
                StopCoroutine(scaleCoroutine);
                scaleCoroutine = null;
            }
            
            targetScale = originalScale;
            rectTransform.localScale = originalScale;
        }
        
        private void OnDestroy()
        {
            if (scaleCoroutine != null)
            {
                StopCoroutine(scaleCoroutine);
            }
        }
    }
}