using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public TextMeshProUGUI achieveCount1;
    
    private Vector2 move;

    public void Update()
    {
        move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed;
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            achieveCount1.text = "DONE";
        }
    }

    public void FixedUpdate()
    {
        transform.Translate(move * Time.deltaTime);
    }

    public void count()
    {
        if(Input.GetKeyDown("up") || Input.GetKeyDown("down")|| Input.GetKeyDown("left")|| Input.GetKeyDown("right"))
        {
            achieveCount1.text = "DONE";
        }
    }
}
