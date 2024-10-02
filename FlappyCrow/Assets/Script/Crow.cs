using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : MonoBehaviour
{
    private Animator animator;
    private string curretAnimation = "";
    private bool isAnimationFinished;
    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        ChangeAnimation("FlyCrow");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * 400);

            }
        }



        if (Input.GetKeyDown(KeyCode.N))
        {
            ChangeAnimation("DieCrow");
            Debug.Log("Holaa");

        }


    }

    private void ChangeAnimation(string animation, float crossfade = 0.2f)
    {
        if (curretAnimation != animation)
        {

            curretAnimation = animation;
            animator.CrossFade(animation, crossfade);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dead"))
        {
            ChangeAnimation("DieCrow");
            isDead = true;

        }
    }

}

