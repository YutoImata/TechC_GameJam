using UnityEngine;  
using System;

namespace Tech.C
{
    [Serializable]
    public class CommentRandomSelector
    {
        [Header("コメントデータ(SO)")]
        public CommentData commentData;

        /// <summary>
        /// SOからランダムでコメントを取得
        /// </summary>
        public string GetRandomComment()
        {
            if (commentData == null || commentData.comments == null || commentData.comments.Count == 0)
                return string.Empty;
            int idx = UnityEngine.Random.Range(0, commentData.comments.Count);
            return commentData.comments[idx];
        }
    }
}