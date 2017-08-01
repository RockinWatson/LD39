using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class ResetGlobalScore : MonoBehaviour
    {
        private Scene s;
        public void Start()
        {
            s = SceneManager.GetActiveScene();
        }
        public void Update()
        {
            if (s.name == "MenuPause_Restart")
            {
                Constants.Globals.Score = 0;
            }
        }
    }
}
