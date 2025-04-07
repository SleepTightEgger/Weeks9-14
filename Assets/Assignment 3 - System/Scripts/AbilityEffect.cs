using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AbilityEffect : MonoBehaviour
{
    public UnityEvent DoEffect;
    public GameObject fireball;
    public PlayerCharacter owner;

    float summoned;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResolveEffect()
    {
        StartCoroutine(SummonFireball());
    }

    IEnumerator SummonFireball()
    {
        float t = 0;
        GameObject fire = Instantiate(fireball, owner.transform.position, Quaternion.identity);
        Destroy(fire, 1);
        while (t < 0.3)
        {
            t += Time.deltaTime;
            yield return null;
        }
        if (summoned < 2)
        {
            summoned++;
            StartCoroutine(SummonFireball());
        } else
        {
            summoned = 0;
        }
    }
}
