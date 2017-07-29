using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class RandomizerSpawner : MonoBehaviour
    {
        public GameObject[] gameObjs;

        //Time to spawn
        public float WaitForNext = 1;
        public float CountDown = 1;

        //X Range
        public float XMin;
        public float XMax;

        //Y Range
        public float YMin;
        public float YMax;

        private Vector2 pos;

        void Update()
        {
            CountDown -= Time.deltaTime;
            if (CountDown <= 0 && GameObject.Find(Constants.Tags.FloaterOne + "(Clone)") != null ||
                                  GameObject.Find(Constants.Tags.FloaterTwo + "(Clone)") != null ||
                                  GameObject.Find(Constants.Tags.FloaterThree + "(Clone)") != null)
            {
                CountDown = WaitForNext;
            }
            else if (CountDown <= 0)
            {
                var enemyPrefab = gameObjs[Random.Range(0, gameObjs.Length)];
                if (enemyPrefab.name != Constants.Tags.FloaterOne)
                {
                    pos = new Vector2(Random.Range(XMin, XMax), Random.Range(0, 0));
                }
                else
                {
                    pos = new Vector2(Random.Range(XMin, XMax), Random.Range(YMin, YMax));
                }
                Instantiate(enemyPrefab, pos, transform.rotation);
            }
        }
    }
}
