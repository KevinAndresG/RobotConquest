using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    [SerializeField] Timer playerTimer; 

    void Start()
    {
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerTimer.enabled = true;
        }
    }
}
