using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayZipSound : MonoBehaviour
{
    public Vector3 lastPos;
    bool play;
    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameObject.Find("EventSystem").GetComponent<MoveLaser>().animateLaser)
        {
            case true:
                if (lastPos != transform.position && play)
                {
                    GetComponent<AudioSource>().Play();
                    play = false;
                }
                lastPos = transform.position;
                if (transform.position == GameObject.Find("EventSystem").GetComponent<MoveLaser>().laserPosition)
                {
                    play = true;
                }
                break;
            case false:
                if (lastPos != transform.position)
                {
                    GetComponent<AudioSource>().Play();
                    lastPos = transform.position;
                }
                break;
        }
    }
}
