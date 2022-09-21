using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int collectedYarn;
    public int collectedKeys;
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
        switch (collision.tag)
        {
            case "Yarn":
                collectedYarn++;
                Destroy(collision.gameObject);
                break;
            case "Key":
                collectedKeys++;
                Destroy(collision.gameObject);
                break;
        }
    }
}
