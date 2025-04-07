using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public GameObject player;
    public Slider visuals;
    public TextMeshProUGUI healthDisplay;

    // Start is called before the first frame update
    void Start()
    {
        visuals.minValue = 0;
        visuals.maxValue = player.GetComponent<PlayerCharacter>().maxHealth;
    }

    void Update()
    {
        if (player != null)
        {
            visuals.value = player.GetComponent<PlayerCharacter>().health;
            healthDisplay.text = player.GetComponent<PlayerCharacter>().health.ToString() + "/" + player.GetComponent<PlayerCharacter>().maxHealth.ToString();
        }
    }
}
