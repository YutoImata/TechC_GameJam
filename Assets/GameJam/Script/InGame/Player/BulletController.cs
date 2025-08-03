using UnityEngine;

namespace Tech.C
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;
        [SerializeField] private float lifeTime = 2f;
        private float timer;
        private Rigidbody2D rb;

        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void Fire(Vector2 direction)
        {
            timer = 0f;
            rb.linearVelocity = direction.normalized * speed;
        }

        void Update()
        {
            timer += Time.deltaTime;
            if (timer >= lifeTime)
            {
                gameObject.SetActive(false);
                /* ===============================
                 * TODO:個々の処理をPoolに返却する処理にする
                 * =============================== */
            }
        }
    }
}