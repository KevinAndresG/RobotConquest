using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    public Timer playerTimer;

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerTimer.enabled = true;
        }
    }
}
