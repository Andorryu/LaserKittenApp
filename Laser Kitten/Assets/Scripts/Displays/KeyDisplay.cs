using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDisplay : MonoBehaviour
{
    public List<GameObject> keys;
    private InventoryManager inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject key in keys)
        {
            if (keys.IndexOf(key) + 1 <= inventory.collectedKeys)
            {
                key.SetActive(true);
            }
            else
            {
                key.SetActive(false);
            }
        }
    }
}
