using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : BaseEnemy
{
    private enum MoveState
    {
        NormalMove,
        TowardPlayer,
    }

    [SerializeField] private MoveState moveState;
    [SerializeField] float moveSpeed;

    [SerializeField] Vector3 startPosition;
    [SerializeField] Vector3 gotoPosition;

    Vector2 moveDirection;
    float startTime = 0;
    bool inPosition = false;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if(Random.value < 0.5f)
        {
            moveState = MoveState.NormalMove;
        }
        else
        {
            moveState = MoveState.TowardPlayer;
        }

        startPosition = transform.position;

        gotoPosition = GetStartPosition();
        gotoPosition.x = transform.position.x;
        gotoPosition.z = transform.position.z;

        moveDirection = Random.value > 0.5f ? Vector2.right : Vector2.left;
        moveSpeed += WaveManager.Instance.currentWave / 4;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y == gotoPosition.y)
        {
            inPosition = true;
        }

        if (inPosition)
        {
            switch (moveState)
            {
                case MoveState.NormalMove:
                    NormalMove(); break;

                case MoveState.TowardPlayer:
                    TowardPlayer(); break;
            }

            rb.velocity = moveDirection * moveSpeed;
        }
        else
        {
            if (startTime < 1)
            {
                startTime += Time.deltaTime;
            }
            transform.position = Vector3.Lerp(startPosition, gotoPosition, startTime);

        }
    }

    public void NormalMove()
    {
        Vector2 worldEdge = Camera.main.ScreenToWorldPoint(Vector2.right * (float)Screen.width);

        if (transform.position.x > worldEdge.x)
        {
            moveDirection = Vector2.left;
        }
        else if (transform.position.x < -worldEdge.x)
        {
            moveDirection = Vector2.right;
        }
    }
    public void TowardPlayer()
    {
        Vector2 worldEdge = Camera.main.ScreenToWorldPoint(Vector2.right * (float)Screen.width);

        if (transform.position.x > worldEdge.x)
        {
            moveDirection = Vector2.left;
        }
        else if (transform.position.x < -worldEdge.x)
        {
            moveDirection = Vector2.right;
        }
    }

    Vector3 GetStartPosition()
    {
        float randomHeight = Random.Range(200, Screen.height);

        return Camera.main.ScreenToWorldPoint(new Vector2(0, randomHeight));
    }
}
