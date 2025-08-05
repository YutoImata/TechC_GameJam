using UnityEngine;
using TMPro; // TextMeshProUGUIを使用するために追加

namespace Tech.C
{
    public class ResultCommentDisplay : MonoBehaviour
    {
        [Header("リザルト用コメントデータ")]
        [SerializeField] private CommentData commentData;
        
        [Header("表示先テキスト")]
        [SerializeField] private TextMeshProUGUI resultText;
        
        private void Start()
        {
            DisplayRandomComment();
        }
        
        private void DisplayRandomComment()
        {
            if (commentData != null && resultText != null)
            {
                string comment = GetRandomComment();
                resultText.text = comment;
            }
        }
        
        private string GetRandomComment()
        {
            if (commentData.comments.Count == 0) return "";
            int randomIndex = Random.Range(0, commentData.comments.Count);
            return commentData.comments[randomIndex];
        }
    }
}