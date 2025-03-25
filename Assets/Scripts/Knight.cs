using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public float speed = 2;
    Animator animator;
    SpriteRenderer sr;
    bool isAttacking;
    bool isInAir;
    bool jumping;
    float combo;
    public float t;
    public AnimationCurve ac;
    public AudioClip[] footsteps;
    public AudioSource footstepSource;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        footstepSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        sr.flipX = direction < 0;
        

        animator.SetFloat("speed", Mathf.Abs(direction));

        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            if (combo == 0)
            {
                animator.SetTrigger("attack");
                isAttacking = true;
            }
            else if (combo == 1)
            {
                animator.SetTrigger("attack2");
                isAttacking = true;
            }
            else if (combo == 2)
            {
                animator.SetTrigger("attack3");
                isAttacking = true;
                combo = 0;
            }

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("jump");
            isInAir = true;
            jumping = true;
            StartCoroutine(Jump());
            
        }

        if (!isAttacking && !isInAir) 
        { 
            transform.position += transform.right * direction * speed * Time.deltaTime;
        }

        if (animator.GetFloat("speed") != 0)
        {
            int randomNumber = Random.Range(0, footsteps.Length);
            footstepSource.PlayOneShot(footsteps[randomNumber]);
        }
    }
    public void AttackHasFinished()
    {
        isAttacking = false;
    }
    public void AttackChain()
    {
        combo += 1;
    }

    IEnumerator Jump()
    {
        Vector3 pos = transform.position;
        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            pos.y = speed * ac.Evaluate(t);
            yield return null;
        }
        isInAir = false;
    }

    IEnumerator FootSteps()
    {
        

        
        yield return null;
    }
}
