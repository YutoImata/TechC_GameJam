using UnityEngine;
using System.Collections.Generic;

namespace Tech.C
{
    [CreateAssetMenu(menuName = "Tech.C/CommentData")]
    public class CommentData : ScriptableObject
    {
        [Header("コメント内容")]
        public List<string> comments = new List<string>();
    }
}