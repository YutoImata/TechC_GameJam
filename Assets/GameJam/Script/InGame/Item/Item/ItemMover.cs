using UnityEngine;
using System.Collections.Generic;

namespace Tech.C.Item
{
    public class ItemMover : MonoBehaviour
    {
        [Header("移動タイプ設定")]
        [SerializeField] private ItemMoveType moveType = ItemMoveType.StraightDown;
        [SerializeField] private bool useRandomMoveType = false;
        [SerializeField] private List<MoveTypeWeight> moveTypeWeights;

        public float fallSpeed = 2f;
        [SerializeField] private Vector2 zigzagDirection = Vector2.right;
        [SerializeField] private float zigzagAmplitude = 1.5f;
        [SerializeField] private float zigzagFrequency = 2f;
        [SerializeField] private GameObject playerObject;
        private Vector3 targetPosition;
        private bool targetSet = false;

        private float zigzagTime = 0f;
        private Vector3 moveDirection; // 進行方向を保存

        private void Awake()
        {
            // ランダムONなら重み付き抽選で決定
            if (useRandomMoveType && moveTypeWeights != null && moveTypeWeights.Count > 0)
            {
                int totalWeight = 0;
                foreach (var w in moveTypeWeights) totalWeight += w.weight;
                
                int rand = Random.Range(0, totalWeight);
                int sum = 0;
                foreach (var w in moveTypeWeights)
                {
                    sum += w.weight;
                    if (rand < sum)
                    {
                        moveType = w.moveType;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// アイテムを動かす処理
        /// </summary>
        public void MoveItem()
        {
            switch (moveType)
            {
                case ItemMoveType.StraightDown:
                    transform.position += Vector3.down * fallSpeed * Time.deltaTime;
                    break;
                case ItemMoveType.ZigZag:
                    zigzagTime += Time.deltaTime;
                    float offset = Mathf.Sin(zigzagTime * zigzagFrequency) * zigzagAmplitude;
                    // Vector2 → Vector3 に変換して加算
                    Vector3 zigzagMove = Vector3.down * fallSpeed * Time.deltaTime + new Vector3(zigzagDirection.x, zigzagDirection.y, 0f) * offset * Time.deltaTime;
                    transform.position += zigzagMove;
                    break;
                case ItemMoveType.ToPlayer:
                    // 最初だけPlayerの位置を保存し、進行方向を決定
                    if (!targetSet && playerObject != null)
                    {
                        targetPosition = playerObject.transform.position;
                        moveDirection = (targetPosition - transform.position).normalized;
                        targetSet = true;
                    }
                    // 進行方向に進み続ける
                    transform.position += moveDirection * fallSpeed * Time.deltaTime;
                    break;
            }
        }
    }

    [System.Serializable]
    public class MoveTypeWeight
    {
        public ItemMoveType moveType;
        [Range(0, 100)] public int weight = 0;
    }
}