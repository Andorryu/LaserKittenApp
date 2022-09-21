using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFade : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Fade").GetComponent<Animator>();
        GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().enabled = false;
        GameObject.Find("EventSystem").GetComponent<MoveLaser>().enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("FadeImage"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().enabled = true;
            GameObject.Find("EventSystem").GetComponent<MoveLaser>().enabled = true;
            Destroy(gameObject);
        }
    }
}
