using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts
{
    public class Enemy : MonoBehaviour
    {
        private string clone = "(Clone)";

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.name == Constants.Enemies.BaddyBigBoy + clone||
                collision.gameObject.name == Constants.Enemies.BaddyBoner + clone ||
                collision.gameObject.name == Constants.Enemies.BaddyIball + clone ||
                collision.gameObject.name == Constants.Enemies.BaddyRoid + clone ||
                collision.gameObject.name == Constants.Enemies.BaddySmallBoy + clone ||
                collision.gameObject.name == "PowerUp(Clone)" ||
                collision.gameObject.name == "Bullet(Clone)" ||
                collision.gameObject.name == "Player")
            {
                Die();
            }
        }

        private void Die()
        {
            FXManager.Get().SpawnExploder(transform.position);
            Destroy(gameObject);
        }
    }
}
