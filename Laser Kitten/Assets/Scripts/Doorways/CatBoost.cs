using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBoost : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool horizontal;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = transform.position;
            // test if booster will give a boost in x or in y
            if (horizontal)
            {
                // test if player's going left or right, give a boost in that direction
                if (rb.velocity.x > 0)
                {
                    rb.velocity = new Vector2(speed, 0);
                }
                else if (rb.velocity.x < 0)
                {
                    rb.velocity = new Vector2(-speed, 0);
                }
            }
            else
            {
                // test if player's going up or down, give a boost in that direction
                if (rb.velocity.y > 0)
                {
                    rb.velocity = new Vector2(0, speed);
                }
                else if (rb.velocity.y < 0)
                {
                    rb.velocity = new Vector2(0, -speed);
                }
            }
            // destroy laser
            Destroy(GameObject.FindGameObjectWithTag("Laser"));
        }
    }
}
