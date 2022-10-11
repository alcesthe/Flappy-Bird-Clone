using UnityEngine;

public class Pipe : MonoBehaviour
{
	public GameObject target;

    void Update()
	{
		float distance = Vector2.Distance(gameObject.transform.position, target.transform.position);

		float offsetLocalScaleY = gameObject.transform.localScale.y / 2 + target.transform.localScale.y / 2;
		float offsetLocalScaleX = gameObject.transform.localScale.x / 2 + target.transform.localScale.x / 2;
		if (distance < offsetLocalScaleY || distance < offsetLocalScaleX)
		{
			Debug.Log("hit");
		}
	}
}
