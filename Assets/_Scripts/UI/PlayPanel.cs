using UnityEngine;
using UnityEngine.UI;

public class PlayPanel : MonoBehaviour
{
    [SerializeField] Text scoreText;
    private void Update()
    {
        scoreText.text = GameManager.instace.score.ToString();
    }
}
