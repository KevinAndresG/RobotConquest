using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    string timer;
    float time;

    void Update()
    {
        time += Time.deltaTime;
        float minutes = ((int)time / 60);
        float seconds = (time % 60);
        timer = string.Format("{0:00}:{1:00}", minutes, seconds);
        UIManager.Instance.UpdateTimer(timer);
        PlayerPrefs.SetString("Time", string.Format("{0:00}:{1:00}", minutes, seconds));
    }
}
