using UnityEngine;

public class LevitationZone : MonoBehaviour
{
    float levitationGravity;
    float normalGravity;
    void Start()
    {
        levitationGravity = -1f;
        normalGravity = 9.8f;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Rigidbody2D>().gravityScale = levitationGravity;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Rigidbody2D>().gravityScale = normalGravity;
        }
    }

}
