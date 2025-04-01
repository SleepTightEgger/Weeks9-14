using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingCollapse : MonoBehaviour
{

    public Tilemap tilemap;
    public AnimationCurve c;
    public float t;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Collapse());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Collapse()
    {
        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            tilemap.transform.localScale = Vector2.one * c.Evaluate(t);
            yield return null;
        }
    }
}
