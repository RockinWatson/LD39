using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class StarSpinRandomizerSpawner : MonoBehaviour
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
            if (CountDown <= 0)
            {
                var enemyPrefab = gameObjs[Random.Range(0, gameObjs.Length)];
                
                pos = new Vector2(Random.Range(XMin, XMax), Random.Range(YMin, YMax));
                Instantiate(enemyPrefab, pos, transform.rotation);
                CountDown = WaitForNext;
            }
        }
    }
}
