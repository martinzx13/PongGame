using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Vector3 startPosition;

    public Rigidbody2D rgb2D;

    public int id;

    

    public float moveSpeed = 6.0f;

    private void Start()
    {
        startPosition = transform.position;
        GameManager.instance.onReset += ResetPosition;
    }

    private void ResetPosition()
    {
        transform.position = startPosition;
    }

    private void Update()
    {
        // This is to make sure that both conditions of the game mode are true.
        if (id == 2 && GameManager.instance.IsPlayer2Ai())
        {
            //call ai move code.
            MoveAi();
        }
        else
        {
            // We keep the same code for the two players.
            float movement = ProcessInput();
            Move (movement);
        }
    }

    private void MoveAi()
    {
        Vector2 ballPos = GameManager.instance.ball.transform.position;
        transform.position = new Vector2(startPosition.x, ballPos.y);
    }

    private float ProcessInput()
    {
        float movement = 0f;
        switch (id)
        {
            case 1:
                movement = Input.GetAxis("MovePlayer1");
                break;
            case 2:
                movement = Input.GetAxis("MovePlayer2");
                break;
        }

        return movement;
    }

    private void Move(float movement)
    {
        Vector2 velocity = rgb2D.velocity;
        velocity.y = moveSpeed * movement;
        rgb2D.velocity = velocity;
    }
}
