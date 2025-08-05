using UnityEngine;

namespace Tech.C.Bullet
{

    /// <summary>
    /// 弾の衝突・範囲外判定を行い、Pool返却処理を担当するクラス
    /// </summary>
    public class BulletCollisionHandler : MonoBehaviour
    {
        private BulletController bulletController;

        void Start()
        {
            bulletController = GetComponent<BulletController>();
        }

        /// <summary>
        /// WallタグのColliderから出たときにPoolへ返却
        /// </summary>
        void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Wall"))
            {
                bulletController.ReturnToPool();
            }
        }

        /// <summary>
        /// アイテムに当たったときにPoolへ返却
        /// </summary>
        void OnTriggerEnter2D(Collider2D other)
        {
            // アイテムのコンポーネントを確認して弾を返却
            if (other.gameObject.GetComponent<Item.EntertainmentItemController>() != null ||
                other.gameObject.GetComponent<Item.GamblingItemController>() != null)
            {
                bulletController.ReturnToPool();
            }
        }
    }
}
