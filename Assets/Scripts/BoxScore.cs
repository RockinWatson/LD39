using UnityEngine;

namespace Assets.Scripts
{
    public class BoxScore : MonoBehaviour
    {
        public GUIText scoreText;

        void UpdateScoreText()
        {
            scoreText.text = Constants.Globals.Score.ToString();
        }
    }
}
