using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Camera.main.transform.position = transform.parent.position + new Vector3(0, 0, -10);
        }
    }
}