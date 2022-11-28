using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
 : MonoBehaviour
{
    public Rigidbody2D rgb2D;

    public int id;

    public float moveSpeed = 6.0f;

    void Update()
    {
        float movement = ProcessInput();
        Move (movement);
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
