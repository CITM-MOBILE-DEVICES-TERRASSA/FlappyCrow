using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : MonoBehaviour
{
    private Animator animator;
    private string curretAnimation = "";
    private bool isAnimationFinished;
    private bool isDead = false;

    private AudioSource audioS;


    [SerializeField]
    private AudioClip deadClip;
    [SerializeField]
    private AudioClip jumpClip;
    [SerializeField]
    private AudioClip passClip;

    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        ChangeAnimation("FlyCrow");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * 400);
                audioS.clip = jumpClip;
                audioS.Play();

            }
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
            if(isDead && !GameController.instance.isCrowDead)
            {
                audioS.clip = deadClip;
                audioS.Play();
            }
            GameController.instance.isCrowDead = true;

        }else if (collision.CompareTag("Pass"))
        {
            audioS.clip = passClip;
            audioS.Play();
            GameController.instance.AddPoint();
        }

    }

}

