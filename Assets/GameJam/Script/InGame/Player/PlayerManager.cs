using UnityEngine;

namespace Tech.C
{
    public class PlayerManager : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public enum GameState
        {
            //Playerがどんな状態か
            Game,
            GamblingGauge,
            EntertainmentGauge,
            None,
        }

        private GameState currentState;//現在の状態
        

        void Start()
        {
            currentState = GameState.Game;//最初にゲーム
        }

        // Update is called once per frame
        void Update()
        {
            switch(currentState)
            {
                case GameState.Game:

                    Debug.Log("プレイヤーはゲームしてます。");
                    break;

               
                case GameState.GamblingGauge:

                    Debug.Log("ギャンブルゲージが溜まりました。");
                    break;

                case GameState.EntertainmentGauge:

                    Debug.Log("娯楽ゲージが溜まりました。");
                    break;

                default:
                case GameState.None:

                    Debug.Log("不明な状態です。");
                    break;
            }


            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                currentState = GameState.None;
            }
            else if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                currentState = GameState.GamblingGauge;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                currentState = GameState.EntertainmentGauge;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                currentState = GameState.Game;
            }

        }
    }
}
