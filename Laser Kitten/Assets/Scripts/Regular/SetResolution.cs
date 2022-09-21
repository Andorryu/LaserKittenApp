using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetResolution : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Screen.SetResolution(1080, 1920, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
