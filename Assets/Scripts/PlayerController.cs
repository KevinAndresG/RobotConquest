using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI CoinText;
    public Animator LifeIndicator;
    public Toggle doubleJumpToggle;
    int Player_Health;
    Rigidbody2D rb;
    [SerializeField] Vector2 bounceVel;
    CapsuleCollider2D playerCapsule;
    Animator anim;
    public bool DoubleJump;
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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerCapsule = GetComponent<CapsuleCollider2D>();
        speed = 10f;
        jumpForce = 73f;
        coinsCollected = 0;
        DoubleJump = false;
        respawn = transform.position;
        Player_Health = 4;
        TimerTrigger.transform.position = transform.position;
        LoockingRight = true;
        distance = 0.1f;
        actualScene = SceneManager.GetActiveScene();
        PlayerPrefs.SetInt("ActualScene", actualScene.buildIndex);
        SoundController.Instance.Music(actualScene.name);
        savedSpeed = speed;
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        anim.SetBool("Run", horizontal != 0.0f);
        if (DoubleJump)
        {
            doubleJumpToggle.isOn = true;
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded)
            {
                Jump();
            }
            else if (DoubleJump)
            {
                Jump();
                DoubleJump = false;
            }
        }
        // Check if the player falls off the map
        if (transform.position.y <= -30)
        {
            Player_Health--;
            SoundController.Instance.PlayEffect(4);
            transform.position = respawn;
            LifeIndicator.SetInteger("Player_Life", Player_Health);
        }
        // Check if the player is dead
        if (Player_Health == 0)
        {
            // SoundController.Instance.audioSource[0].Stop();
            // SoundController.Instance.Music(1);
            SoundController.Instance.PlayEffect(3);
            PlayerPrefs.SetString("sceneName", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("LosScreen");
        }
        // Checking where the player is looking
        if (LoockingRight && horizontal < 0 || LoockingRight == false && horizontal > 0)
        {
            LoockingRight = !LoockingRight;
            // transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            // transform.Rotate(new Vector3(0, 180, 0));
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
        // Turn on and Turn off the double jump
        if (DoubleJump == false)
        {
            doubleJumpToggle.isOn = false;
        }
        if (DoubleJump == false && IsGrounded)
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
            CoinText.text = $"{coinsCollected}";
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
            LifeIndicator.SetInteger("Player_Life", Player_Health);
        }
        if (other.tag == "Full_Life")
        {
            Player_Health = MAX_HEALTH;
            Destroy(other.gameObject);
            LifeIndicator.SetInteger("Player_Life", Player_Health);
        }
        if (other.tag == "DoubleJump")
        {
            DoubleJump = true;
            other.gameObject.SetActive(false);
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
    }
    void OnTriggerStay2D(Collider2D other)
    {
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
    }
    // take the damage and bounce
    public void TakeDamage(Vector2 damagePosition)
    {
        Player_Health--;
        LifeIndicator.SetInteger("Player_Life", Player_Health);
        Bounce(damagePosition);
    }
    public void Bounce(Vector2 hitPoint)
    {
        rb.velocity = new Vector2(-bounceVel.x * hitPoint.x, bounceVel.y);
    }
}
