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

    private MoveState moveState;
    [SerializeField] float moveSpeed;

    [SerializeField] Vector3 startPosition;
    [SerializeField] Vector3 gotoPosition;

    float startTime = 0;
    // Start is called before the first frame update
    void Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        if(startTime < 1)
        {
            startTime += Time.deltaTime;
        }
        transform.position = Vector3.Lerp(startPosition, gotoPosition, startTime);

        switch(moveState)
        {
            case MoveState.NormalMove:
                NormalMove(); break;

            case MoveState.TowardPlayer:
                TowardPlayer(); break;
        }
    }

    public void NormalMove()
    {

    }
    public void TowardPlayer()
    {

    }

    Vector3 GetStartPosition()
    {
        float randomHeight = Random.Range(200, Screen.height);

        return Camera.main.ScreenToWorldPoint(new Vector2(0, randomHeight));
    }
}
