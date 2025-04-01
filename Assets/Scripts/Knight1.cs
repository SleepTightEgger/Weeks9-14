using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Knight1 : MonoBehaviour
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
    AudioSource footstepSource;
    public CinemachineImpulseSource impulseSource;

    public Tilemap tilemap;
    public Tile grass;
    public Tile stone;

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

        if (Input.GetMouseButtonDown(0) )
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3Int gridPos = tilemap.WorldToCell(mousePos);

            Vector3 start = transform.position;

            if (tilemap.GetTile(gridPos) == stone)
            {
                StartCoroutine(ClickToMove(start, gridPos));
            }
            else
            {
                Debug.Log("Clicked Grass");
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
    }
    public void AttackHasFinished()
    {
        isAttacking = false;
    }
    public void AttackChain()
    {
        combo += 1;
    }
    public void PlayFootStep()
    {
        int randomNumber = Random.Range(0, footsteps.Length);
        footstepSource.PlayOneShot(footsteps[randomNumber]);
        impulseSource.GenerateImpulse();
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

    IEnumerator ClickToMove(Vector3 start, Vector3Int gridPos)
    {
        t = 0;
        while (t < 1)
        {
            float direction = gridPos.x - start.x;
            t += Time.deltaTime;
            transform.position += Vector3.Lerp(start, gridPos, 1) * direction * speed * Time.deltaTime;
            animator.SetFloat("speed", Mathf.Abs(direction));
            yield return null;
        }
    }
}
