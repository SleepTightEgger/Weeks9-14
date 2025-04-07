using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Manabar : MonoBehaviour
{
    public GameObject player;
    public Slider visuals;
    public TextMeshProUGUI manaDisplay;

    // Start is called before the first frame update
    void Start()
    {
        visuals.minValue = 0;
        visuals.maxValue = player.GetComponent<PlayerCharacter>().maxMana;
    }

    void Update()
    {
        if (player != null)
        {
            visuals.value = player.GetComponent<PlayerCharacter>().mana;
            manaDisplay.text = player.GetComponent<PlayerCharacter>().mana.ToString() + "/" + player.GetComponent<PlayerCharacter>().maxMana.ToString();
        }
    }
}
