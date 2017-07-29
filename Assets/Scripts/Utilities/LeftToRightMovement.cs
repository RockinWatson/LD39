using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class LeftToRightMovement : MonoBehaviour
    {
        private float _randomSpeed;

        void Start()
        {
            _randomSpeed = Random.Range(0.01f, 0.03f);
        }

        void Update()
        {
            transform.Translate(Vector2.left * _randomSpeed);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.name == Constants.Tags.LeftToRightDestroy)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
