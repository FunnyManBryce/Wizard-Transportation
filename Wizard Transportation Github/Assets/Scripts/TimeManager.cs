using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float timeScale = 60.0f;
    public float startTime = 0f;

    public float currentTime = 600f;
    private const float minutesInDay = 1440f;

    private void Start()
    {
        currentTime = startTime;
    }
    void Update()
    {
        float deltaTime = Time.deltaTime * timeScale;

        currentTime += deltaTime;

        if (currentTime >= minutesInDay)
        {
            currentTime -= minutesInDay;
        }

        int currentHour = Mathf.FloorToInt(currentTime / 60f);
        int currentMinute = Mathf.FloorToInt(currentTime % 60f);

        Debug.LogFormat("Current Time: {0:D2}:{1:D2}", currentHour, currentMinute);
    }
}
