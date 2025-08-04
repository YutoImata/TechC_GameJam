using UnityEngine;
using TMPro;

namespace Tech.C
{
    public class CommentDisplay : MonoBehaviour
    {
        [Header("コメント抽選クラス（Serializable）")]
        public CommentRandomSelector randomSelector;
        [Header("コメント移動クラス（Prefabにアタッチ）")]
        public CommentMover commentMoverPrefab;
        [Header("表示するTMPオブジェクトの親")] 
        public Transform displayParent;
        [Header("表示間隔（秒）")]
        public float displayInterval = 2f;
        [Header("コメントPool")]
        public CommentPool commentPool;

        private float timer;

        private void Update()
        {
            timer += Time.deltaTime;
            if (timer >= displayInterval)
            {
                DisplayRandomComment();
                timer = 0f;
            }
        }

        /// <summary>
        /// ランダムコメントを生成・表示
        /// </summary>
        private void DisplayRandomComment()
        {
            string comment = randomSelector != null ? randomSelector.GetRandomComment() : "";
            if (string.IsNullOrEmpty(comment)) return;

            // PoolからTMP取得
            var tmp = commentPool.GetComment();
            tmp.transform.SetParent(displayParent, false);
            tmp.text = comment;
            tmp.fontSize = 36;
            tmp.color = Color.white;
            tmp.alignment = TextAlignmentOptions.Center;
            tmp.gameObject.SetActive(true);

            // 表示終了時にPoolへ返却（例: 3秒後に非表示）
            StartCoroutine(ReturnCommentAfterDelay(tmp, 3f));
        }

        private System.Collections.IEnumerator ReturnCommentAfterDelay(TextMeshProUGUI tmp, float delay)
        {
            yield return new WaitForSeconds(delay);
            tmp.gameObject.SetActive(false);
            commentPool.ReturnComment(tmp);
        }
    }
}