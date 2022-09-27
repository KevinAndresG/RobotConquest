using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    Animator anim;
    [SerializeField] Transform shootStart;
    [SerializeField] GameObject bullet;
    float lastShoot;
    public float canShoot;

    void Start()
    {
        anim = GetComponent<Animator>();
        canShoot = 0.2f;
    }
    void Update()
    {
        Shoot();
    }
    // Shoot when fire1 is pressed
    void Shoot()
    {
        if (Input.GetButton("Fire1") && Time.time > lastShoot + canShoot)
        {
            lastShoot = Time.time;
            // anim.SetBool("Shooting", true);
            Instantiate(bullet, new Vector3(shootStart.position.x, shootStart.position.y, 0), shootStart.rotation);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            // anim.SetBool("Shooting", false);
        }
    }
}
