using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class RandomQuotes : MonoBehaviour
    {
        public GameObject[] gameObjs;

        private Vector2 playerPos;
        
        //Time to spawn
        private float WaitForNext = 2f;
        private float CountDown = 1f;

        private void Start()
        {
            playerPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        }

        void Update()
        {           
            CountDown -= Time.deltaTime / 5;
            if (CountDown <= 0)
            {
                var prefab = gameObjs[Random.Range(0, gameObjs.Length)];
                var obj = Instantiate(prefab, playerPos, transform.rotation);

                StartCoroutine(WaitToDestroy(obj));
                CountDown = WaitForNext;
            }
        }

        IEnumerator WaitToDestroy(GameObject obj)
        {
            yield return new WaitForSeconds(2.5f);
            Destroy(obj);
        }
    }
}
