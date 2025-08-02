using UnityEngine;

namespace Tech.C
{
    public class Test : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                AudioManager.I.PlaySound("test");
            }
        }
    }
}