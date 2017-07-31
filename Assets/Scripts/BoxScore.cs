using UnityEngine;

namespace Assets.Scripts
{
    public class BoxScore : MonoBehaviour
    {
        public GUIText scoreText;

        void Awake()
        {
            scoreText.text = Constants.Globals.Score.ToString();
        }
    }
}
