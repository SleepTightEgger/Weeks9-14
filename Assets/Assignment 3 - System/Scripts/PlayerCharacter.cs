using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCharacter : MonoBehaviour
{
    public float health;
    public float mana;
    public float maxHealth;
    public float maxMana;
    public GameObject owner;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HealthRegen());
        StartCoroutine(ManaRegen());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            health -= 20;
            health = Mathf.Clamp(health, 0, maxHealth);
        }

        if (health <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(owner);
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        float t = 0;
        while (t < 5)
        {
            t += Time.deltaTime;
            yield return null;
        }
        Instantiate(owner);
    }

    IEnumerator HealthRegen()
    {
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            yield return null;
        }
        if (health < maxHealth)
        {
            health += 1;
        }
        StartCoroutine(HealthRegen());
    }

    IEnumerator ManaRegen()
    {
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            yield return null;
        }
        if (mana < maxMana)
        {
            mana += 1;
        }
        StartCoroutine(ManaRegen());
    }
}
