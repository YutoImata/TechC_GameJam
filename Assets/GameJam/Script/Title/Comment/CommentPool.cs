using UnityEngine;
using TMPro;

namespace Tech.C
{
    public class CommentPool : MonoBehaviour
    {
        private ObjectPool<TextMeshProUGUI> pool;

        [SerializeField] private TextMeshProUGUI commentPrefab;
        [SerializeField] private Transform parent;
        [SerializeField] private int initialSize = 10;

        private void Awake()
        {
            pool = new ObjectPool<TextMeshProUGUI>(
                () => Instantiate(commentPrefab, parent),
                parent,
                initialSize
            );
        }

        public TextMeshProUGUI GetComment()
        {
            return pool.Get();
        }

        public void ReturnComment(TextMeshProUGUI comment)
        {
            pool.Return(comment);
        }
    }
}