using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class RowRandomizer : MonoBehaviour
    {
        public GameObject[] gameObjs;

        //Time to spawn
        public float WaitForNext = 1;
        public float CountDownMin = 2;
        public float CountDownMax = 3;

        private float CountDown;

        //X Range
        public float XMin;
        public float XMax;

        //Y Range
        public float YMin;
        public float YMax;

        private Vector2 pos;

        void Update()
        {
            CountDown = Random.Range(CountDownMin, CountDownMax);
            CountDown -= Time.deltaTime;
            if (CountDown <= 0)
            {
                var enemyPrefab = gameObjs[Random.Range(0, gameObjs.Length)];

                pos = new Vector2(Random.Range(XMin, XMax), Random.Range(YMin, YMax));
                Instantiate(enemyPrefab, pos, transform.rotation);
                CountDown = Random.Range(CountDownMin, CountDownMax);
            }
        }
    }
}
