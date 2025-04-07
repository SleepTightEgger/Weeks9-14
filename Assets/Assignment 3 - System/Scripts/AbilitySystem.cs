using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AbilitySystem : MonoBehaviour
{

    public UnityEvent OnAbilityActivated;

    public PlayerCharacter owner;

    public GameObject[] abilities;
    public List<GameObject> instantiatedAbilities = new List<GameObject>();

    public Ability selectedAbility;

    public Slider Icon1;
    public Slider Icon2;
    public Slider Icon3;
    public Slider Icon4;

    void Start()
    {
        for (int i = 0; i < abilities.Length; i++)
        {
            GameObject ability = Instantiate(abilities[i]);
            ability.GetComponent<Ability>().owner = owner;

            instantiatedAbilities.Add(ability);
        }

        instantiatedAbilities[0].GetComponent<Ability>().cooldownMeter = Icon1;
        instantiatedAbilities[1].GetComponent<Ability>().cooldownMeter = Icon2;
        instantiatedAbilities[2].GetComponent<Ability>().cooldownMeter = Icon3;
        instantiatedAbilities[3].GetComponent<Ability>().cooldownMeter = Icon4;
    }

    public void ActivateAbility()
    {
        if (!selectedAbility.GetComponent<Ability>().onCooldown && owner.GetComponent<PlayerCharacter>().mana >= selectedAbility.GetComponent<Ability>().manaCost)
        {
            selectedAbility.GetComponent<Ability>().OnCommitAbility.Invoke();
            Debug.Log("Ability " + selectedAbility + " Invoked");
            selectedAbility = null;
        } 
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (selectedAbility != null)
            {
                OnAbilityActivated.Invoke();
            }
            else
            {
                Debug.Log("Basic Attack");
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            selectedAbility = null;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedAbility = instantiatedAbilities[0].GetComponent<Ability>();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedAbility = instantiatedAbilities[1].GetComponent<Ability>();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedAbility = instantiatedAbilities[2].GetComponent<Ability>();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedAbility = instantiatedAbilities[3].GetComponent<Ability>();
        }
    }
}
