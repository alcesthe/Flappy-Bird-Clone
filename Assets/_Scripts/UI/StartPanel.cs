using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
	[SerializeField] Button startButton;
	void Awake()
	{
		startButton.onClick.AddListener(delegate
		{
			GameManager.instace.ChangeState(GameManager.GameState.Playing);
		});
	}
}
