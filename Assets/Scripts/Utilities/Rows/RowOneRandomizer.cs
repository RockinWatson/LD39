using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Utilities.Rows
{
    public class RowOneRandomizer : MonoBehaviour
    {
        public GameObject[] gameObjs;

        private float Xpos = 9.45f;
        private float _outterRowY = 2.85f;
        private float _secondRowY = 1.44f;
        private float _middleRowY = 0f;

        private float[] rowNums;

        //Time to spawn
        public float WaitForNext = 1;

        private float CountDown;

        private Vector2 pos;

        void Start()
        {
            rowNums = new float[] { _outterRowY, _secondRowY, _middleRowY, -_secondRowY, -_outterRowY };
        }

        void Update()
        {
            CountDown -= Time.deltaTime;

            if (CountDown <= 0)
            {
                var yPos = Random.Range(0, rowNums.Length);
                pos = new Vector2(Xpos, rowNums[yPos]);
                InstantiateObj(pos);
                CountDown = WaitForNext;
            }
        }

        private void InstantiateObj(Vector2 pos)
        {
            //FirstRow
            if (pos.y == _outterRowY)
            {
                var enemyPrefab = PrioritizeObjs(gameObjs);
                EnemenyInstantiate(pos, Constants.Names.RowOne, enemyPrefab);
            }
            //SecondRow
            if (pos.y == _secondRowY)
            {
                var enemyPrefab = PrioritizeObjs(gameObjs);
                EnemenyInstantiate(pos, Constants.Names.RowTwo, enemyPrefab);
            }
            //ThirdRow
            if (pos.y == _middleRowY)
            {
                var enemyPrefab = PrioritizeObjs(gameObjs);
                EnemenyInstantiate(pos, Constants.Names.RowThree, enemyPrefab);
            }
            //FourthRow
            if (pos.y == -_secondRowY)
            {
                var enemyPrefab = PrioritizeObjs(gameObjs);
                EnemenyInstantiate(pos, Constants.Names.RowFour, enemyPrefab);
            }
            //FifthRow
            if (pos.y == -_outterRowY)
            {
                var bottomObjs = gameObjs;
                var sendObjs = bottomObjs.Where((source, index) => index != 4).ToArray();
                var enemyPrefab = sendObjs[Random.Range(0, sendObjs.Length)];
                EnemenyInstantiate(pos, Constants.Names.RowFive, enemyPrefab);
            }
        }

        private void EnemenyInstantiate(Vector2 pos, string row, GameObject enemyPrefab)
        {
            GameObject newObj;
            if (!enemyPrefab.name.Contains(Constants.Enemies.BaddyBigBoy))
            {
                newObj = Instantiate(enemyPrefab, pos, transform.rotation);
            }
            else
            {
                var newPos = new Vector2(pos.x, pos.y - 0.71f);
                newObj = Instantiate(enemyPrefab, newPos, transform.rotation);
            }           
        }

        private GameObject PrioritizeObjs(GameObject[] objArray)
        {
            var range = Random.Range(0,100);
            //BaddyBoner
            if (range >= 0 && range <= 30)
            {
                return objArray[0];
            }
            //BaddyRoid
            if (range >= 31 && range <= 50)
            {
                return objArray[2];
            }
            //BaddyIball
            if (range >= 51 && range <= 60)
            {
                return objArray[1];
            }
            //BaddySmallBoy
            if (range >= 61 && range <= 70)
            {
                return objArray[3];
            }
            //BaddyBigBoy
            if (range >= 71 && range <= 80)
            {
                return objArray[4];
            }
            //PowerUP
            if (range >= 81 && range <= 100)
            {
                return objArray[5];
            }
            return null;
        }
    }
}
