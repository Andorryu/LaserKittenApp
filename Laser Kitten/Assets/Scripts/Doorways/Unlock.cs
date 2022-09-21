using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // test if collided with player
        if (collision.gameObject.CompareTag("Player"))
        {
            // tests if the player has keys
            if (collision.gameObject.GetComponent<InventoryManager>().collectedKeys > 0)
            {
                collision.gameObject.GetComponent<InventoryManager>().collectedKeys--;
                transform.parent.gameObject.SetActive(false);
            }
        }
    }
}
