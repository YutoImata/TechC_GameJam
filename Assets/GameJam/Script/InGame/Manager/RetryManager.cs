using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tech.C
{
    public class RetryManager : MonoBehaviour
    {       
        public void RestartGame()
        {
            string lastSceneName = PlayerPrefs.GetString("lastPlayedScene");
            // 値が空でなければ、そのシーンをロードする
            if (!string.IsNullOrEmpty(lastSceneName))
            {
                SceneManager.LoadScene(lastSceneName);
            }
            else
            {
                SceneController.I.LoadScene("Title");

            }

            // Update is called once per frame
          
        }
    }
}
