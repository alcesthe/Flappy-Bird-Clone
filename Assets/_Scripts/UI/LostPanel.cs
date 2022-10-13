using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LostPanel : MonoBehaviour
{
	[SerializeField] Text scoreText;
	[SerializeField] Animator flashImage;
	[SerializeField] Button retryButton;

    void Awake()
	{
		retryButton.onClick.AddListener(delegate
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			GameManager.instace.ResetAction();
		});
	}

    private void Update()
	{
		scoreText.text = "Your score: " + GameManager.instace.score;
	}

	public void Flash()
    {
		flashImage.SetTrigger("flashTrigger");
    }
}
