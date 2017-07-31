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
        public float WaitForNext = 5f;

        private float CountDown;

        private Vector2 pos;
        private Vector2 newPos;

        void Start()
        {
            rowNums = new float[] { _outterRowY, _secondRowY, _middleRowY, -_secondRowY, -_outterRowY };
        }

        void Update()
        {          
            CountDown -= Time.deltaTime * 2;

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
            newPos = new Vector2(pos.x, pos.y - 0.71f);
            if (enemyPrefab.name != Constants.Enemies.BaddyBigBoy + "(Clone)")
            {
                Instantiate(enemyPrefab, pos, transform.rotation);
            }
            else
            {
                Instantiate(enemyPrefab, newPos, transform.rotation);               
            }           
        }

        private GameObject PrioritizeObjs(GameObject[] objArray)
        {
            var range = Random.Range(0,100);
            //Roid
            if (range >= 0 && range <= 50)
            {
                return objArray[2];
            }
            //boner
            if (GameObject.Find(Constants.Enemies.BaddyBoner + "(Clone)") != null && range >= 51 && range <= 70)
            {
                return objArray[2];
            }
            else if(range >= 51 && range <= 70)
            {
                return objArray[0];
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
            if (range >= 80 && range <= 90)
            {
                return objArray[4];
            }
            //PowerUP
            if (range >= 95 && range <= 100)
            {
                return objArray[5];
            }
            return objArray[2];
        }
    }
}
