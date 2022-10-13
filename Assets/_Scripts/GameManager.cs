using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public enum GameState
    {
		Start,
		Playing,
		Lost
    }

    public enum PowerUp
    {
        None,
        Strength,
        Slow,
        Explosion
    }

	public static GameManager instace;
    public int score = 0;
    public GameState state;
    public PowerUp currentPowerUp;
    public bool isPowerUpActive = false;

    
    [SerializeField] GameObject playPanel;
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject lostPanel;

    public static event Action onBeforeChange;
    public static event Action onAfterChange;

    private GameObject player;
    private bool isLost = false;

    void Awake()
	{
		if (instace != null)
        {
			Destroy(gameObject);
        }
        else
        {
			instace = this;
        }
	}

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ChangeState(GameState.Start);
        currentPowerUp = PowerUp.None;
    }

    public void ChangeState(GameState changedState)
    {
        onBeforeChange?.Invoke();

        state = changedState;
        switch (changedState)
        {
			case GameState.Start:
				HandleStart();
				break;
			case GameState.Playing:
				HandlePlaying();
				break;
			case GameState.Lost:
				HandleLost();
				break;
		}

        onAfterChange?.Invoke();
    }

    private void HandleStart()
    {
        startPanel.SetActive(true);
        onBeforeChange = delegate
        {
            startPanel.SetActive(false);
        };
    }

    private void HandleLost()
    {
        if (!isLost)
        {
            player.GetComponent<Player>().Dead();
            lostPanel.SetActive(true);
            lostPanel.GetComponent<LostPanel>().Flash();
            isLost = true;
        }
    }

    private void HandlePlaying()
    {
        Debug.Log("Playing");
    }

    public void ResetAction()
    {
        onBeforeChange = null;
        onAfterChange = null;
    }
}
