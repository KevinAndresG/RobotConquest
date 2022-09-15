using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector2 Min;
    public Vector2 Max;
    public float smooth;
    Vector2 speed;

    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref speed.x, smooth);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref speed.y, smooth);
        transform.position = new Vector3(Mathf.Clamp(posX, Min.x, Max.x), Mathf.Clamp(posY, Min.y, Max.y), transform.position.z);
    }
}
