using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class RightMovement : MonoBehaviour
    {   
        public float minRange;
        public float maxRange;

        private float _randomSpeed;

        void Start()
        {
            _randomSpeed = Random.Range(minRange, maxRange);
        }

        void Update()
        {
            transform.Translate(Vector2.right * _randomSpeed);
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
