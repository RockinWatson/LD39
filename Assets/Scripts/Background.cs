using UnityEngine;

public class Background : MonoBehaviour {

    public float offSpeed = 10f;

    void Update () {

        MeshRenderer mr = GetComponent<MeshRenderer>();

        Material mat = mr.material;

        Vector2 offset = mat.mainTextureOffset;

        offset.x += Time.deltaTime / offSpeed;

        mat.mainTextureOffset = offset;
	}
}
