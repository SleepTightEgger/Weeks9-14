using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alpha1 : MonoBehaviour
{
    public SpriteRenderer sr;
    public TrailRenderer tr;
    void Start()
    {
        tr.startColor = sr.color;
        tr.endColor = sr.color;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = mousePos;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            sr.color = Random.ColorHSV();
            tr.startColor = sr.color;
            tr.endColor = sr.color;
        }
    }
}
