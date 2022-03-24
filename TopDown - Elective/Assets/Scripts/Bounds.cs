using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    private float playerH, playerW;
    private Vector2 screenSize;

    private void Start()
    {
        playerW = transform.localScale.x / -2;
        playerH = transform.localScale.y / -2;
        screenSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize + playerW, Camera.main.orthographicSize + playerH);
    }

    private void Update()
    {
        Border();
    }

    private void Border()
    {
        if (transform.position.x < -screenSize.x)
        {
            transform.position = new Vector2(-screenSize.x, transform.position.y);
        }
        else if (transform.position.x > screenSize.x)
        {
            transform.position = new Vector2(screenSize.x, transform.position.y);
        }

        if (transform.position.y < -screenSize.y)
        {
            transform.position = new Vector2(transform.position.x, -screenSize.y);
        }
        else if (transform.position.y > screenSize.y)
        {
            transform.position = new Vector2(transform.position.x, screenSize.y);
        }
    }

}
