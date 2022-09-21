using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmationManager : MonoBehaviour
{
    public GameObject confirmation1;
    public GameObject confirmation2;
    // Start is called before the first frame update
    void Start()
    {
        // 02039A7C
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Confirm1(bool confirm)
    {
        confirmation1.SetActive(confirm);
    }
    public void Confirm2(bool confirm)
    {
        confirmation2.SetActive(confirm);
    }
}
