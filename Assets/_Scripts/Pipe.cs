using UnityEngine;

public class Pipe : MonoBehaviour
{
	private GameObject player;
	private SpriteRenderer pipeSpriteRenderer;
	private SpriteRenderer playerSpriteRenderer;
	private float pipeSizeX, pipeSizeY;
	private float playerSizeX, playerSizeY;

    private void Start()
    {
		pipeSpriteRenderer = GetComponent<SpriteRenderer>();
		pipeSizeX = pipeSpriteRenderer.bounds.extents.x;
		pipeSizeY = pipeSpriteRenderer.bounds.extents.y;

		player = GameObject.FindGameObjectWithTag("Player");
		playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
		playerSizeX = playerSpriteRenderer.bounds.extents.x;
		playerSizeY = playerSpriteRenderer.bounds.extents.y;	
	}


	void Update()
	{
		float distanceX = Mathf.Abs(transform.position.x - player.transform.position.x);
		float distanceY = Mathf.Abs(transform.position.y - player.transform.position.y);

		float offsetLocalScaleX = pipeSizeX + playerSizeX;
		float offsetLocalScaleY = pipeSizeY + playerSizeY;

/*		Debug.Log("Distance X: " + distanceX + " Offset X: " + (offsetLocalScaleX));
		Debug.Log("Distance Y: " + distanceY + " Offset Y: " + (offsetLocalScaleY));*/

		if(distanceX <= (playerSizeX + pipeSizeX) && distanceY <= (playerSizeY + pipeSizeY))
        {
			Debug.Log("Pipe Hit");
        }
	}
}
