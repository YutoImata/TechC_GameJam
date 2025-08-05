using UnityEngine;
using TMPro; // TextMeshProUGUIを使用するために追加
using System.Collections;

namespace Tech.C
{
    public class ResultCommentDisplay : MonoBehaviour
    {
        [Header("リザルト用コメントデータ")]
        [SerializeField] private CommentData commentData;
        
        [Header("表示先テキスト")]
        [SerializeField] private TextMeshProUGUI resultText;
        
        [Header("タイプライター設定")]
        [SerializeField] private float typeSpeed = 0.05f; // 1文字あたりの表示間隔（秒）
        [SerializeField] private bool skipOnClick = true; // クリックでスキップ可能か
        
        private string fullText = "";
        private bool isTyping = false;
        
        private void OnEnable()
        {
            DisplayRandomComment();
        }
        
        private void Update()
        {
            // クリックでスキップ
            if (skipOnClick && isTyping && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
            {
                SkipTypewriter();
            }
        }
        
        private void DisplayRandomComment()
        {
            if (commentData != null && resultText != null)
            {
                string comment = GetRandomComment();
                if (!string.IsNullOrEmpty(comment))
                {
                    StartTypewriter(comment);
                }
                else
                {
                    resultText.text = "コメントが見つかりません";
                }
            }
        }
        
        private string GetRandomComment()
        {
            if (commentData.comments.Count == 0) return "";
            int randomIndex = Random.Range(0, commentData.comments.Count);
            return commentData.comments[randomIndex];
        }
        
        /// <summary>
        /// タイプライター効果を開始
        /// </summary>
        private void StartTypewriter(string text)
        {
            fullText = text;
            resultText.text = "";
            isTyping = true;
            StartCoroutine(TypewriterCoroutine());
        }
        
        /// <summary>
        /// タイプライター効果のコルーチン
        /// </summary>
        private IEnumerator TypewriterCoroutine()
        {
            for (int i = 0; i <= fullText.Length; i++)
            {
                if (!isTyping) break; // スキップされた場合
                
                resultText.text = fullText.Substring(0, i);
                yield return new WaitForSeconds(typeSpeed);
            }
            
            isTyping = false;
        }
        
        /// <summary>
        /// タイプライター効果をスキップ
        /// </summary>
        private void SkipTypewriter()
        {
            if (isTyping)
            {
                isTyping = false;
                resultText.text = fullText;
            }
        }
        
        /// <summary>
        /// 外部から手動でコメントを更新する場合に使用
        /// </summary>
        public void RefreshComment()
        {
            DisplayRandomComment();
        }
    }
}