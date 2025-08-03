using UnityEngine;

namespace Tech.C
{
    public static class LoggerManager
    {
        public static void Log(string message)
        {
            if (GameManager.I != null && GameManager.I. IsDebug)
            {
                Debug.Log(message);
                // Consoleにも出したい場合は、ConsoleManagerにメソッド追加も可
            }
        }

        public static void LogWarning(string message)
        {
            if (GameManager.I != null && GameManager.I.IsDebug)
            {
                Debug.LogWarning(message);
            }
        }

        public static void LogError(string message)
        {
            if (GameManager.I != null && GameManager.I.IsDebug)
            {
                Debug.LogError(message);
            }
        }
    }
}