using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    float time;

    void Update()
    {
        time += Time.deltaTime;
        float minutes = ((int)time / 60);
        float seconds = (time % 60);
        TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
