using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public Transform clockPivot; 
    public TimeManager timeManager; 

    void Update()
    {

        float hourAngle = 360f * (timeManager.currentTime / 1440f);

        transform.position = clockPivot.position;
        transform.rotation = Quaternion.Euler(0f, 0f, -hourAngle);
    }
}
