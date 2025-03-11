using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EventsDemo : MonoBehaviour
{
    public GameObject banana;

    public UnityEvent OnTimerExpired;
    public float timerLength = 2;
    public float t;

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t > timerLength)
        {
            t = 0;
            OnTimerExpired.Invoke();
        }
    }

    public void ButtonPushed()
    {
        Debug.Log("Button Pushed");
    }

    public void ButtonPushedAgain()
    {
        Debug.Log("Button Pushed Again");
    } 

    public void Entered()
    {
        Debug.Log("Entered Sprite Area");
        banana.transform.localScale = Vector3.one * 1.2f;
    }

    public void Exited()
    {
        Debug.Log("Exited Sprite Area");
        banana.transform.localScale = Vector3.one * 1f;
    }

    public void TimerExpired()
    {
        Debug.Log("Timer Expired");
    }
}
