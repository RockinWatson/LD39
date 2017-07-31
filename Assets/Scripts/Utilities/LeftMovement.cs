using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class LeftMovement : MonoBehaviour
    {   
        public float minRange;
        public float maxRange;

        private bool _keyPause() { return (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)); }

        private float _randomSpeed;

        void Start()
        {
            _randomSpeed = Random.Range(minRange, maxRange);
        }

        void Update()
        {
            transform.Translate(Vector2.left * _randomSpeed);

            if (Constants.Globals.Score >= 100)
            {
                _randomSpeed = 0.105f;
            }
            if (Constants.Globals.Score >= 200)
            {
                _randomSpeed = 0.110f;
            }
            if (Constants.Globals.Score >= 300)
            {
                _randomSpeed = 0.115f;
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.name == Constants.Names.LeftDestroy)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
