using UnityEngine;

namespace Assets.Scripts
{
    public class Explode : MonoBehaviour
    {
        private const float DELAY = 0.1f;

        private Animator _anim = null;

        private void Awake()
        {
            _anim = this.GetComponent<Animator>();
        }

        private void Start()
        {
            Destroy(gameObject, _anim.GetCurrentAnimatorStateInfo(0).length + DELAY);
        }
    }
}
