using UnityEngine;

public class Pickup : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PowerUp(Clone)" || collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }
    }

}
