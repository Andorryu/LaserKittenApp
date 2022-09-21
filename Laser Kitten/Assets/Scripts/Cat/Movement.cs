using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //references
    private Rigidbody2D rb;
    // laser gameobject
    public GameObject laser;

    // AddForce cat speed
    public float speed;
    public float frictionCoefficient;

    // true when cat touches laser trigger
    public bool reachLaserRadius;

    // direction contains values between -1 and 1 for each of x and y. This value is multiplied by speed in order to get exactly how much speed in the x and y is necessary for a correct total speed
    private Vector2 direction = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // only update player's speed and direction if the laser exists
        if (GameObject.FindGameObjectWithTag("Laser") != null)
        {
            laser = GameObject.FindGameObjectWithTag("Laser");
            UpdateDirection();
            MoveCat();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == laser)
        {
            reachLaserRadius = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == laser)
        {
            reachLaserRadius = false;
        }
    }
    void UpdateDirection()
    {
        // x and y components of distance from player to laser
        float angle;
        Vector2 sides;
        sides = laser.transform.position - transform.position;

        // angle that makes a straight line from player to laser
        if (sides.x > 0)
        {
            angle = Mathf.Atan(sides.y / sides.x);
        }
        else
        {
            angle = Mathf.Atan(sides.y / sides.x) + Mathf.PI;
        }

        // update rotation
        transform.eulerAngles = new Vector3(0, 0, angle * 180 / Mathf.PI);

        // direction vector that will be multiplied by speed value to get the correct speed in the x and y
        direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }
    void MoveCat()
    {
        // only give cat a speed when the cat isn't on the laser
        if (!reachLaserRadius)
        {
            rb.velocity = speed * direction;
        }
        else
        {
            // apply friction
            rb.velocity -= Time.deltaTime * rb.velocity * new Vector2(frictionCoefficient, frictionCoefficient);
        }
    }
}
