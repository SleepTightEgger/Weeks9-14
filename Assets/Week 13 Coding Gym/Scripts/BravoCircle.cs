using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BravoCircle : MonoBehaviour
{
    public SpriteRenderer sr;
    float t;
    public bool changing;

    // Update is called once per frame
    void Update()
    {

    }

    public void sizeHolder(float size)
    {
        StartCoroutine(sizeChange(size));
    }

    public IEnumerator sizeChange(float size)
    {
        t = 0;
        Vector2 sizeChange = new Vector2(size, size);
        changing = true;
        while (t < 0.5)
        {
            t += Time.deltaTime;
            transform.localScale = Vector2.Lerp(transform.localScale, sizeChange, t);
            yield return null;
        }
        changing = false;
    }
}
