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
            switch (currentState)
            {
                case GameState.Game:
                    break;
                case GameState.GamblingGauge:
                    break;
                case GameState.EntertainmentGauge:
                    break;
                default:
                case GameState.None:
                    break;
            }


            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                currentState = GameState.None;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
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
