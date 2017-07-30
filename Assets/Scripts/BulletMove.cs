using UnityEngine;

public class BulletMove : MonoBehaviour {

    public float Speed;

    void Update()
    {
        transform.Translate(Vector2.right * Speed);
    }
}
