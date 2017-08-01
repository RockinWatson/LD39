using Assets.Scripts.Utilities.Rows;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Utilities
{
    public class FXManager : MonoBehaviour
    {
        static private FXManager _singleton = null;
        static public FXManager Get() { return _singleton; }

        private float nextSceneTimer = 1f;

        DBFunctions dbfunc;

        [SerializeField]
        private GameObject _exploder = null;

        private void Awake()
        {
            _singleton = this;
            dbfunc = new DBFunctions();
        }

        private void Update()
        {          
            if (GameObject.Find("Player") == null)
            {                
                nextSceneTimer -= Time.deltaTime;
                if (nextSceneTimer <= 0)
                {  
                        SceneManager.LoadScene("GameOver");
                }
            }
        }

        public void SpawnExploder(Vector3 pos)
        {
            GameObject explode = (GameObject)Instantiate(_exploder);
            explode.transform.position = pos;
        }
    }
}
