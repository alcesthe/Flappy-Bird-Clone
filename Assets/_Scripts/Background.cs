using UnityEngine;

public class Background : MonoBehaviour
{
	[Range(-1f,1f)]
	[SerializeField] float scrollSpeed = 0.5f;
	private float offset;
	private Material material;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        offset += (Time.deltaTime * scrollSpeed) / 10f;
        material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
