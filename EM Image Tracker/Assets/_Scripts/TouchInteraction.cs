using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TouchInteraction : MonoBehaviour {

    // You can add listeners in inspector
    public UnityEvent OnSingleTap;
    public UnityEvent OnDoubleTap;


    float firstTapTime = 0f;
    float timeBetweenTaps = 0.2f; // time between taps to be resolved in double tap
    bool doubleTapInitialized;

    void OnMouseDown()
    {
        if (!doubleTapInitialized)
        {
            // invoke single tap after max time between taps
            Invoke("SingleTap", timeBetweenTaps);
            // init double tapping
            doubleTapInitialized = true;
            firstTapTime = Time.time;
        }
        else if (Time.time - firstTapTime < timeBetweenTaps)
        {
            // here we have tapped second time before "single tap" has been invoked
            CancelInvoke("SingleTap"); // cancel "single tap" invoking
            DoubleTap();
        }
    }

    void SingleTap()
    {
        doubleTapInitialized = false; // deinit double tap

        // fire OnSingleTap event for all eventual subscribers
        if(OnSingleTap != null)
        {
            OnSingleTap.Invoke();
        }
    }

    void DoubleTap()
    {
        doubleTapInitialized = false;
        if(OnDoubleTap != null)
        {
            OnDoubleTap.Invoke();
        }
    }
}
