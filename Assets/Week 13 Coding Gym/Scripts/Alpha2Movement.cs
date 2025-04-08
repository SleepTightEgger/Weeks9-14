using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alpha2Movement : MonoBehaviour
{
    float speed = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mousePos - (Vector2)transform.position;

        transform.up = direction;

        transform.position += transform.up * speed * Time.deltaTime;

        if ((Vector2)transform.position == mousePos)
        {
            Destroy(gameObject);
        }
    }
}
