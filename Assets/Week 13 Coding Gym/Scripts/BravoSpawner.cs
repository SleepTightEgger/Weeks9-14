using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BravoSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Slider slider;

    void Start()
    {
        slider.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPrefab()
    {
        GameObject circle = Instantiate(prefab, Random.insideUnitCircle * 5, transform.rotation);
        BravoCircle bravoCircle = circle.GetComponent<BravoCircle>();

        Vector2 size = Vector2.one * slider.value;

        if (!bravoCircle.changing) { 
            slider.onValueChanged.AddListener(bravoCircle.sizeHolder);
        } else
        {
            slider.onValueChanged.RemoveListener(bravoCircle.sizeHolder);
        }
    }
}
