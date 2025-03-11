using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerEvents : MonoBehaviour
{
    public Image banana;
    public List<Sprite> foods;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnteredArea()
    {
        banana.sprite = foods[Random.Range(1, 24)];
        Debug.Log("Hello");
    }

    public void ExitedArea()
    {
        banana.sprite = foods[0];
    }
    public void Clicked()
    {
        GameObject newPrefab = Instantiate(prefab);
    }
}