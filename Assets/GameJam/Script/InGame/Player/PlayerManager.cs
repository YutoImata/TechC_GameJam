using UnityEngine;

namespace Tech.C
{
    public class PlayerManager : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public enum PlayerState
        {
            //Playerがどんな状態か
            Game,
            None,
            GamblingGauge,
            EntertainmentGauge,
        }

        public PlayerState CurrentState;//現在の状態
        

        void Start()
        {
            CurrentState = PlayerState.Game;//最初にゲーム
        }

        // Update is called once per frame
        void Update()
        {
            switch(CurrentState)
            {
                case PlayerState.Game:

                    Debug.Log("プレイヤーはゲームしてます。");
                    break;

                case PlayerState.None:

                    Debug.Log("ノーマルエンドです。");
                    break;

                case PlayerState.GamblingGauge:

                    Debug.Log("ギャンブルゲージが溜まりました。");
                    break;

                case PlayerState.EntertainmentGauge:

                    Debug.Log("娯楽ゲージが溜まりました。");
                    break;

                default:

                    Debug.Log("不明な状態です。");
                    break;
            }


            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                CurrentState = PlayerState.None;
            }
            else if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                CurrentState = PlayerState.GamblingGauge;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                CurrentState = PlayerState.EntertainmentGauge;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                CurrentState = PlayerState.Game;
            }

        }
    }
}
