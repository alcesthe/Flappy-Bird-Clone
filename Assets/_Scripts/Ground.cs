using UnityEngine;

public class Ground : MonoBehaviour
{
	private GameObject player;
    private SpriteRenderer groundSpriteRenderer;
    private SpriteRenderer playerSpriteRenderer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
        groundSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
	{
        float distanceY = player.transform.position.y - transform.position.y;
        if (distanceY <= (playerSpriteRenderer.bounds.extents.y + groundSpriteRenderer.bounds.extents.y))
        {
			Debug.Log("Ground hit");
        }
	}
}
