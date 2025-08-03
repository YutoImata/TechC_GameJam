using UnityEngine;

namespace Tech.C
{
    public class BulletCollisionHandler : MonoBehaviour
    {
        private BulletController bulletController;
        void Start()
        {
            bulletController = GetComponent<BulletController>();
        }
        void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Wall"))
            {
                bulletController.ReturnToPool();
            }
        }
    }
}