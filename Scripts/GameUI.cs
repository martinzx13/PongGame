using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
	public TextMeshProUGUI winText;

	public TextMeshProUGUI volumeValueText;

	public TextMeshProUGUI playModeButtomText;

	public GameObject menuObject;

	public System.Action onStartGame;

	public ScoreText

			scoreTextPlayer1,
			scoreTextPlayer2;

	public void Awake()
	{
		AdjustPlayModeButtomText();
	}
	public void UpdateScores(int player1Score, int player2Score)
	{
		scoreTextPlayer1.SetScore (player1Score);
		scoreTextPlayer2.SetScore (player2Score);
	}

	public void HighlightScore(int id)
	{
		if (id == 1)
		{
			scoreTextPlayer1.Highlight();
		}
		else
		{
			scoreTextPlayer2.Highlight();
		}
	}

	public void OnsStartGameButtonClicked()
	{
		menuObject.SetActive(false);
		onStartGame?.Invoke();
	}

	public void OnGameEnds(int winnerId)
	{
		menuObject.SetActive(true);
		winText.text = $"Player {winnerId} Wins Siuuuu";
	}

	public void OnVolumeChanged(float value)
	{
		AudioListener.volume = value;
		volumeValueText.text = $"{Mathf.RoundToInt(value * 100)}%";
	}

	// This Method will be updated any time that the buttom is pressed.
	public void OnSwitchPlayModeButtonClicked()
	{
		GameManager.instance.SwitchPlayMode();
		AdjustPlayModeButtomText();
	}

	private void AdjustPlayModeButtomText()
	{
		// Define a string


		switch (GameManager.instance.playMode)
		{
			case GameManager.PlayMode.PlayerVsPlayer:
				playModeButtomText.text = "2 Players";
				break;
			case GameManager.PlayMode.PlayerVsAi:
				playModeButtomText.text = "Player VS AI";
				break;
		}

	}
}
