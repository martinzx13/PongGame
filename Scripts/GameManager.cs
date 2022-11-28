using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int maxScore = 4;

    public static GameManager instance;

    public GameUI gameUI;

    public BallManager ball;

    public GameAudio gameAudio;

    public int

            player1Score,
            player2Score;

    public System.Action onReset;

    public PlayMode playMode;

    // This is to write an integer spell out as a string
    public enum PlayMode
    {
        PlayerVsPlayer,
        PlayerVsAi
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy (gameObject);
        }
        else
        {
            instance = this;
            gameUI.onStartGame += OnStartGame;
        }
    }

    public void OnScoreZoneReached(int id)
    {
        if (id == 1)
        {
            player1Score++;
        }

        if (id == 2)
        {
            player2Score++;
        }
        gameUI.UpdateScores (player1Score, player2Score);
        gameUI.HighlightScore (id);
        CheckWin();
    }

    private void CheckWin()
    {
        int winnerId =
            player1Score == maxScore ? 2 : player2Score == maxScore ? 1 : 0;
        if (winnerId != 0)
        {
            gameAudio.PlayWinSound();
            gameUI.OnGameEnds (winnerId);
        }
        else
        {
            gameAudio.PlayScoreSound();
            onReset?.Invoke();
        }
    }

    private void OnStartGame()
    {
        player1Score = 0;
        player2Score = 0;
        gameUI.UpdateScores (player1Score, player2Score);
    }

    // This method is to change between the methods in the game mode.
    public void SwitchPlayMode()
    {
        switch (playMode)
        {
            // If we are in the player vs player will move to player vs Ai
            case PlayMode.PlayerVsPlayer:
                playMode = PlayMode.PlayerVsAi;
                break;
            case PlayMode.PlayerVsAi:
                playMode = PlayMode.PlayerVsPlayer;
                break;
        }
    }

    //compair the play modes
    public bool IsPlayer2Ai()
    {
        return playMode == PlayMode.PlayerVsAi;
    }
}
