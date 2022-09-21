using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool move;
        if (Mathf.Abs(rb.velocity.x) <= 1 && Mathf.Abs(rb.velocity.y) <= 1)
            move = false;
        else
            move = true;

        anim.SetBool("move", move);
    }
}
