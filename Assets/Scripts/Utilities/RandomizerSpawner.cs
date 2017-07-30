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
            if (CountDown <= 0 && GameObject.Find(Constants.Names.FloaterOne + "(Clone)") != null ||
                                  GameObject.Find(Constants.Names.FloaterTwo + "(Clone)") != null ||
                                  GameObject.Find(Constants.Names.FloaterThree + "(Clone)") != null)
            {
                CountDown = WaitForNext;
            }
            else if (CountDown <= 0)
            {
                var floaterPrefab = gameObjs[Random.Range(0, gameObjs.Length)];
                if (floaterPrefab.name != Constants.Names.FloaterOne)
                {
                    pos = new Vector2(Random.Range(XMin, XMax), Random.Range(0, 0));
                }
                else
                {
                    pos = new Vector2(Random.Range(XMin, XMax), Random.Range(YMin, YMax));
                }
                Instantiate(floaterPrefab, pos, transform.rotation);
            }
        }
    }
}
