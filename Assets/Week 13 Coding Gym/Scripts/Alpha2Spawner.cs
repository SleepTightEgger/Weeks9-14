using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alpha2Spawner : MonoBehaviour
{
    public GameObject prefab;
    public CinemachineImpulseSource impulseSource;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(prefab, mousePos, Quaternion.identity);
            impulseSource.GenerateImpulse();
        }
    }
}
