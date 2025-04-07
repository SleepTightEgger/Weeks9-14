using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEditor.Playables;

public class Ability : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent OnCommitAbility;
    public UnityEvent OnCancelAbility;

    public PlayerCharacter owner;
    public float manaCost;
    public float cooldown;

    public GameObject[] abilityEffects;

    public Slider cooldownMeter;

    public float t;

    public bool activated;
    public bool onCooldown;

    void Start()
    {
        //cooldownMeter = GetComponent<Slider>();
        cooldownMeter.maxValue = cooldown;
    }

    public void AbilityActivated()
    {
        StartCoroutine(DoCooldown());
        StartCoroutine(DoManaReduction());
        for (int i = 0; i < abilityEffects.Length; i++)
        {
            GameObject effect = Instantiate(abilityEffects[i]);
            effect.GetComponent<AbilityEffect>().owner = owner;
            effect.GetComponent<AbilityEffect>().DoEffect.Invoke();
            Destroy(effect, 2);
        }
    }

    IEnumerator DoCooldown()
    {
        t = cooldown;
        onCooldown = true;
        while (t > 0)
        {
            t -= Time.deltaTime;
            cooldownMeter.value = t % cooldownMeter.maxValue;
            yield return null;
        }
        onCooldown = false;
    }

    IEnumerator DoManaReduction()
    {
        owner.GetComponent<PlayerCharacter>().mana -= manaCost;
        yield return null;
    }
}
