using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLaser : MonoBehaviour
{    
    // laser prefab
    public GameObject laserPrefab;
    // laser gameobject
    public GameObject laser;

    // makes laser physically move to new position rather than teleport
    public bool animateLaser;
    [Header("Laser Speed is only affected if Animate Laser is checked")]
    public float laserSpeed;
    public Vector2 laserDirection;

    // laserPosition changes with each new click
    public Vector3 laserPosition;

    // Update is called once per frame
    void Update()
    {
        SetLaserPosition();
    }
    private void FixedUpdate()
    {
        StopLaserIfAnimated();
    }
    void SetLaserPosition()
    {
        // when clicking or tapping and mouse isn't over the pause button
        if (Input.GetMouseButtonDown(0) && !GameObject.Find("EventSystem").GetComponent<PauseManager>().hoverOverMouse && !GameObject.Find("EventSystem").GetComponent<Objective>().win)
        {
            // this is unnecessary because GetMouseButtonDown() works in android mobile
            /*
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    // set laserPosition to tapped spot
                    laserPosition = Input.GetTouch(0).rawPosition;
                }
            }
            */

            laserPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10); // without adding 10 in the z, laser will spawn at -10 in the z (the z of the camera)

            /*
            if (Input.GetMouseButtonDown(0))
            {
                // set laserposition to the mouse's position
                laserPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10); // without adding 10 in the z, laser will spawn at -10 in the z (the z of the camera)
            }
            */

            // if cannot find a laser
            if (laser == null)
            {
                // create a laser @ laserPostion
                laser = Instantiate(laserPrefab, laserPosition, new Quaternion(0, 0, 0, 0));
            }
            // if can find a laser
            else
            {
                if (animateLaser)
                {
                    float angle;
                    Vector2 sides;
                    sides = laserPosition - laser.transform.position;

                    // angle that makes a straight line from player to laser
                    if (sides.x >= 0)
                    {
                        angle = Mathf.Atan(sides.y / sides.x);
                    }
                    else
                    {
                        angle = Mathf.Atan(sides.y / sides.x) + Mathf.PI;
                    }

                    laserDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

                    laser.GetComponent<Rigidbody2D>().velocity = laserSpeed * laserDirection;
                }
                else
                {
                    // set its position to laserPosition
                    laser.transform.position = laserPosition;
                }
            }
        }
    }
    void StopLaserIfAnimated()
    {
        if (animateLaser && laser != null)
        {
            // if the laser gets close to its target position
            if (laser.transform.position.x < laserPosition.x + .5 && laser.transform.position.x > laserPosition.x - .5
                && laser.transform.position.y < laserPosition.y + .5 && laser.transform.position.y > laserPosition.y - .5)
            {
                // stop the laser
                laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                // put laser where it's supposed to be
                laser.transform.position = laserPosition;
            }
        }
    }
}
