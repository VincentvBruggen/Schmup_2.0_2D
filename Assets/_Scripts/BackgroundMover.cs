using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 200;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * (moveSpeed * Time.deltaTime);

        if(transform.position.y + 5 < Camera.main.ScreenToWorldPoint(Vector2.right * (float)Screen.width).y)
        {
            transform.position = Vector3.up * 25;
        }
    }
}
