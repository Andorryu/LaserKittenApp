using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damager : MonoBehaviour
{
    // use this variable so that CountAttempts() isn't called twice in the case of colliding with multiple walls at once
    private bool lost;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lost)
        {
            // Call CountAttempts from EventSystem's StatisticsTracker script
            GameObject.Find("EventSystem").GetComponent<StatisticsTracker>().CountAttempts();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lost = true;
        }
    }
}
