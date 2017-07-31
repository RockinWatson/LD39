using Assets.Scripts;
using UnityEngine;

public class BulletMove : MonoBehaviour {

    public float Speed;

    public Animation anim;

    private string clone = "(Clone)";

    private float deathTimer = 0.0f;

    private void Start()
    {
        anim = GetComponent<Animation>();
        anim.wrapMode = WrapMode.Loop;
        anim["DeathExploder"].wrapMode = WrapMode.Once;
    }

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
            PlayAnimation();
        }
    }

    void PlayAnimation()
    {
        deathTimer++;
        anim.CrossFade("DeathExploder");
        if (deathTimer > 0.5)
        {
            Destroy(gameObject);
        }
    }
}
