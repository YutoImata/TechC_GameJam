using UnityEngine;

namespace Tech.C
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField]
        private bool isDebug;

        public bool IsDebug => isDebug;
    }
}