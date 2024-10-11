using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    float moveSpeed = 5;
    [SerializeField] GameObject[] tilemaps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < tilemaps.Length; i++) 
        {
            tilemaps[i].transform.position += Vector3.down * (moveSpeed * Time.deltaTime);

            if (tilemaps[i].transform.position.y + 5 < Camera.main.ScreenToWorldPoint(Vector2.right * (float)Screen.width).y)
            {
                tilemaps[i].transform.position = Vector3.up * 20;
            }
        }
    }
}
