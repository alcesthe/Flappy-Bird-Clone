using UnityEngine;

public class StrengthPU : MonoBehaviour
{
	private GameObject player;
	private Player playerScript;
	private SpriteRenderer powerUpSpriteRenderer;
	private SpriteRenderer playerSpriteRenderer;
	private float pipeSizeX, pipeSizeY;
	private float playerSizeX, playerSizeY;

	[SerializeField] float powerUpTime = 10f;
	[SerializeField] float speed = 5;
	[SerializeField] float rangeToDestroy = -10;
	[SerializeField] float delayActionTime = 1;
	[SerializeField] AudioClip soundSFX;


	private void Start()
	{
		powerUpSpriteRenderer = GetComponent<SpriteRenderer>();
		pipeSizeX = powerUpSpriteRenderer.bounds.extents.x;
		pipeSizeY = powerUpSpriteRenderer.bounds.extents.y;

		player = GameObject.FindGameObjectWithTag("Player");
		playerScript = player.GetComponent<Player>();
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

		if (distanceX <= (playerSizeX + pipeSizeX) && distanceY <= (playerSizeY + pipeSizeY))
		{
			if (!playerScript.CheckPowerUpIsAvailable())
			{
				playerScript.powerUpSound = soundSFX;
				playerScript.SetPowerUpAction(delegate
				{
					GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
					playerObj.GetComponent<Player>().isInvicible = true;
					playerObj.GetComponent<SpriteRenderer>().color = Color.red;
				});

				playerScript.SetPowerUpDelayAction(delegate
				{
					GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
					playerObj.GetComponent<Player>().isInvicible = false;
					playerObj.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
				}, delayActionTime);

				GameManager.instace.currentPowerUp = GameManager.PowerUp.Strength;
				Destroy(gameObject);
			}
		}

		if (GameManager.instace.state == GameManager.GameState.Playing)
		{
			MovingObject();
		}
		DestroyWhenOutRange();
	}



	private void MovingObject()
	{
		transform.Translate(Vector2.left * Time.deltaTime * speed);
	}

	private void DestroyWhenOutRange()
	{
		if (transform.position.x < rangeToDestroy)
		{
			Destroy(gameObject);
		}
	}
}
