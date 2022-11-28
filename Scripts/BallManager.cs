using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public BallAudio ballAudio;

    public Rigidbody2D rbd2d;

    public float speed = 3.0f;

    private float angleMovement = 0.90f;

    private float posX = 0f;

    private float maxposY = 4.0f;

    private float speedMultiplier = 1.1f;

    private void Start()
    {
        GameManager.instance.onReset += RestartBall;
        GameManager.instance.gameUI.onStartGame += RestartBall;
    }

    void InitialPush()
    {
        Vector2 dir = Random.value < 0.5 ? Vector2.left : Vector2.right;
        dir.y = Random.Range(-angleMovement, angleMovement);
        rbd2d.velocity = dir * speed;
    }

    private void RestartBall()
    {
        ResetBallPosition();
        InitialPush();
    }

    void ResetBallPosition()
    {
        float posY = Random.Range(-maxposY, maxposY);
        Vector2 position = new Vector2(posX, posY);
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreZone scoreZone = collision.GetComponent<ScoreZone>();
        if (scoreZone)
        {
            GameManager.instance.OnScoreZoneReached(scoreZone.id);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Paddle paddle = collision.collider.GetComponent<Paddle>();
        if (paddle)
        {
            ballAudio.PlayPaddleSound();
            rbd2d.velocity *= speedMultiplier;
        }

        Walls walls = collision.collider.GetComponent<Walls>();
        if (walls)
        {
            ballAudio.PlayWallSound();
        }
    }
}
