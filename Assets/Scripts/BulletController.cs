using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] FlyingHead enemy1;
    void Start()
    {
        speed = 40f;
    }
    void Update()
    {
        transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("FlyingHead"))
        {
            other.gameObject.GetComponent<FlyingHead>().TakeDamage(1);
            Destroy(gameObject);
        }
        if (other.gameObject)
        {
            Destroy(gameObject);
        }
    }
}
