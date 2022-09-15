using UnityEngine;

public class FlyingHead : MonoBehaviour
{
    public int lifes;
    [SerializeField] GameObject deathEffect;

    void Start()
    {
        lifes = 4;
    }
    void Update()
    {
        if (lifes <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
        lifes -= 1;
    }
}
