using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class GlobalScore : MonoBehaviour
    {
        public GUIText scoreText;

        private float timer = 0;
        private float timerMax = 0;

        void Update()
        {
            if (Waited(5))
            {
                Constants.Globals.Score += 5;
                timer = 0;
            }
            UpdateScoreText();
        }

        void UpdateScoreText()
        {
            scoreText.text = Constants.Globals.Score.ToString();
        }

        private bool Waited(float seconds)
        {
            timerMax = seconds;
            timer += Time.deltaTime;
            if (timer >= timerMax)
            {
                return true;
            }
            return false;
        }
    }
}
