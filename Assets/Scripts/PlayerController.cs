using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Toggle doubleJumpToggle;
    int Player_Health;
    Rigidbody2D rb;
    [SerializeField] Vector2 bounceVel;
    CapsuleCollider2D playerCapsule;
    Animator anim;
    // public bool DoubleJump;
    public GameObject doubleJ;
    public LayerMask floorLayer;
    public float distance;
    float horizontal;
    public float speed;
    float savedSpeed;
    public float jumpForce;
    public Transform IsGroundedCheck;
    public bool IsGrounded;
    Vector3 respawn;
    int coinsCollected;
    public GameObject TimerTrigger;
    bool LoockingRight;
    Scene actualScene;
    public const int MAX_HEALTH = 4;

    [SerializeField] Transform aim;
    public Vector2 facingDirection;
    [SerializeField] Camera cam;
    [SerializeField] float aimOffset;
    [SerializeField] GameObject bullet;
    float lastShoot;
    public float canShoot;
    [SerializeField] Transform shootStart;
    Timer timer;
    


    void Start()
    {
        speed = 10f;
        jumpForce = 73f;
        coinsCollected = 0;
        // DoubleJump = false;
        respawn = transform.position;
        Player_Health = 4;
        LoockingRight = true;
        distance = 0.1f;
        actualScene = SceneManager.GetActiveScene();
        PlayerPrefs.SetInt("ActualScene", actualScene.buildIndex);
        SoundController.Instance.Music(actualScene.name);
        savedSpeed = speed;
        TimerTrigger = GameObject.FindGameObjectWithTag("TimerTrigger");
        playerCapsule = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        TimerTrigger.transform.position = transform.position;
        timer = GetComponent<Timer>();
    }
    public void StartElements()
    {
        cam = Camera.main;
        doubleJ = GameObject.FindGameObjectWithTag("DoubleJump");
        canShoot = 0.2f;

    }
    void Update()
    {
        // Aim Movement
        facingDirection = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        aim.position = transform.position + (Vector3)facingDirection.normalized * aimOffset;

        if (Input.GetButton("Fire1") && Time.time > lastShoot + canShoot)
        {
            lastShoot = Time.time;
            // anim.SetBool("Shooting", true);
            float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Instantiate(bullet, shootStart.position, targetRotation);
            SoundController.Instance.PlayEffect(10);
        }
        // if (Input.GetButtonUp("Fire1"))
        // {
        //     anim.SetBool("Shooting", false);
        // }
        if (aim.position.x < transform.position.x && LoockingRight || LoockingRight == false && aim.position.x > transform.position.x)
        {
            LoockingRight = !LoockingRight;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
        horizontal = Input.GetAxisRaw("Horizontal");
        anim.SetBool("Run", horizontal != 0.0f);
        if (UIManager.Instance.DoubleJump)
        {
            UIManager.Instance.doubleJumpToggle.isOn = true;
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded)
            {
                Jump();
            }
            else if (UIManager.Instance.DoubleJump)
            {
                Jump();
                UIManager.Instance.DoubleJump = false;
            }
        }
        // Check if the player falls off the map
        if (transform.position.y <= -30)
        {
            Player_Health--;
            SoundController.Instance.PlayEffect(4);
            transform.position = respawn;
            UIManager.Instance.UpdateHealth(Player_Health);
        }
        // Check if the player is dead
        if (Player_Health == 0)
        {
            // SoundController.Instance.audioSource[0].Stop();
            //  SoundController.Instance.Music(1);
            SoundController.Instance.PlayEffect(3);
            PlayerPrefs.SetString("sceneName", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("LosScreen");
        }
        // Checking where the player is looking
        if (LoockingRight && horizontal < 0 || LoockingRight == false && horizontal > 0)
        {
            LoockingRight = !LoockingRight;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
            // transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            // transform.Rotate(new Vector3(0, 180, 0));
        }
        
        if (UIManager.Instance.DoubleJump == false && IsGrounded)
        {
            doubleJ.SetActive(true);
        }
    }
    void FixedUpdate()
    {
        // Player movement
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        IsGrounded = Physics2D.OverlapCircle(IsGroundedCheck.position, distance, floorLayer);
    }
    // Jump Function
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        SoundController.Instance.PlayEffect(0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            Destroy(other.gameObject);
            coinsCollected++;
            PointsController.Instance.CoinCounter(1);
            UIManager.Instance.UpdateScore(coinsCollected);
            SoundController.Instance.PlayEffect(1);
        }
        if (other.tag == "Goal")
        {
            PlayerPrefs.SetInt("CoinsPerLevel", coinsCollected);
            SceneManager.LoadScene("WinScreen");
            SoundController.Instance.PlayEffect(2);
        }
        if (other.tag == "One_life")
        {
            Player_Health++;
            Destroy(other.gameObject);
            if (Player_Health > 4)
            {
                Player_Health = MAX_HEALTH;
            }
            UIManager.Instance.UpdateHealth(Player_Health);
            SoundController.Instance.PlayEffect(7);
        }
        if (other.tag == "Full_Life")
        {
            Player_Health = MAX_HEALTH;
            Destroy(other.gameObject);
            UIManager.Instance.UpdateHealth(Player_Health);
            SoundController.Instance.PlayEffect(8);
        }
        if (other.tag == "DoubleJump")
        {
            UIManager.Instance.DoubleJump = true;
            other.gameObject.SetActive(false);
            SoundController.Instance.PlayEffect(6);
        }
        if (other.tag == "FlyingHead" || other.tag == "Crusher")
        {
            SoundController.Instance.PlayEffect(4);
            TakeDamage(transform.position);
        }
        if (other.tag == "Saw" || other.tag == "Nails")
        {
            TakeDamage(transform.position);
            SoundController.Instance.PlayEffect(4);
        }
        // the speed zone enter
        if (other.tag == "SpeedZone")
        {
            speed = savedSpeed * 2;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        // the speed zone exit
        if (other.tag == "SpeedZone")
        {
            speed = savedSpeed;
        }
        if (other.tag == "TimerTrigger")
        {
            timer.enabled = true;
        }
    }
    // take the damage and bounce
    public void TakeDamage(Vector2 damagePosition)
    {
        Player_Health--;
        UIManager.Instance.UpdateHealth(Player_Health);
        Bounce(damagePosition);
    }
    public void Bounce(Vector2 hitPoint)
    {
        rb.velocity = new Vector2(-bounceVel.x * hitPoint.x, bounceVel.y);
    }
}
