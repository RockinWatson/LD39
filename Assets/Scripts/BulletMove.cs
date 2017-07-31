using Assets.Scripts;
using UnityEngine;

public class BulletMove : MonoBehaviour {

    public float Speed;

    private string clone = "(Clone)";

    void Update()
    {
        transform.Translate(Vector2.right * Speed);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == Constants.Names.RightDestroy ||
            collision.gameObject.name == Constants.Enemies.BaddyBigBoy + clone ||
            collision.gameObject.name == Constants.Enemies.BaddyBoner + clone ||
            collision.gameObject.name == Constants.Enemies.BaddyIball + clone ||
            collision.gameObject.name == Constants.Enemies.BaddyRoid + clone ||
            collision.gameObject.name == Constants.Enemies.BaddySmallBoy + clone)
        {
            SoundController.explosion.Play();
            Destroy(gameObject);
            Constants.Globals.Score += 10;
        }
    }
}
