using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeEnemy : BaseEnemy
{
    [SerializeField] float moveSpeed;

    [SerializeField] float startTime;
    [SerializeField] Vector3 startPosition;
    [SerializeField] Vector3 gotoPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;

        gotoPosition = GetStartPosition();
        gotoPosition.x = transform.position.x;
        gotoPosition.z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != gotoPosition)
        {
            transform.position = Vector3.Lerp(startPosition, gotoPosition, Time.deltaTime);
        }   
    }

    Vector3 GetStartPosition()
    { 
        float randomHeight = Random.Range(200, Screen.height);

        return Camera.main.ScreenToWorldPoint(new Vector2(0, randomHeight));
    }
}
