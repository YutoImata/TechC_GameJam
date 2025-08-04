using UnityEngine;
using Tech.C;


public class SceneControllerTest : MonoBehaviour
{
    void Update()
    {
        // キー1を押したら「TitleScene」に遷移
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Load TitleScene");
            SceneController.I.LoadScene("Title");
        }

        // キー2を押したら「GameScene」に遷移
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Load GameScene");
            SceneController.I.LoadScene("InGame");
        }

        // キー3を押したら非同期で「GameScene」に遷移
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Load GameScene Async");
            SceneController.I.LoadScene("Result");
        }
    }
}
