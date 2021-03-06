using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody;
    public float speed= 60f;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        transform.eulerAngles = new Vector3(0, 0, Random.value * 360f);
    }

    public void SetTrajectory(Vector2 direction)
    {
        rigidbody.AddForce(direction * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.tag == "Bullet")
       {
            Destroy(this.gameObject);
       }
       if (collision.gameObject.tag == "Player")
       {
            Destroy(this.gameObject);
       }
    }
}
