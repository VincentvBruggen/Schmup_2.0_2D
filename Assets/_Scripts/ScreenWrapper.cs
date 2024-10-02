using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    [SerializeField] float margin;
    [SerializeField] Vector2 worldEdge;
    // Start is called before the first frame update
    void Start()
    {     
        worldEdge = Camera.main.ScreenToWorldPoint(Vector2.right * (float)Screen.width);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > worldEdge.x + margin)
        {
            transform.position = new Vector2(-transform.position.x + 0.1f, transform.position.y);
        }
        else if (transform.position.x < -worldEdge.x - margin)
        {
            transform.position = new Vector2(-transform.position.x - 0.1f, transform.position.y);
        }
    }
}
