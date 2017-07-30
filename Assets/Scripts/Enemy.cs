using UnityEngine;

namespace Assets.Scripts
{
    public class Enemy : MonoBehaviour
    {
        private string clone = "(Clone)";
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name == Constants.Enemies.BaddyBigBoy + clone||
                collision.gameObject.name == Constants.Enemies.BaddyBoner + clone ||
                collision.gameObject.name == Constants.Enemies.BaddyIball + clone ||
                collision.gameObject.name == Constants.Enemies.BaddyRoid + clone ||
                collision.gameObject.name == Constants.Enemies.BaddySmallBoy + clone)
            {
                Destroy(gameObject);
            }
        }
    }
}
