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

	public static GameManager instace;
	void Awake()
	{
		if (instace != null)
        {
			Destroy(gameObject);
        }
        else
        {
			instace = this;
			DontDestroyOnLoad(gameObject);
        }
	}

    private void Start() => ChangeState(GameState.Start);

    public void ChangeState(GameState state)
    {
        switch (state)
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
    }

    private void HandleLost()
    {
        throw new NotImplementedException();
    }

    private void HandlePlaying()
    {
        throw new NotImplementedException();
    }

    private void HandleStart()
    {
        throw new NotImplementedException();
    }
}
