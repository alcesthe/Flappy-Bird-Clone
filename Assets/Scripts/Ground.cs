using UnityEngine;

public class Ground : MonoBehaviour
{
	[SerializeField] GameObject player;
	void Update()
	{
		if (player.transform.position.y <= (transform.position.y + transform.localScale.y))
        {
			Debug.Log("Ground hit");
        }
	}
}
