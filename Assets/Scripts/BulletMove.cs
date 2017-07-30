using Assets.Scripts;
using UnityEngine;

public class BulletMove : MonoBehaviour {

    public float Speed;

    void Update()
    {
        transform.Translate(Vector2.right * Speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == Constants.Names.RightDestroy)
        {
            Destroy(this.gameObject);
        }
    }
}
