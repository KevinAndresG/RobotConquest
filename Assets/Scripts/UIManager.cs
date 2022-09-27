using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Animator LifeIndicator;
    public Toggle doubleJumpToggle;
    public bool DoubleJump;
    public static UIManager Instance;
    [SerializeField] TextMeshProUGUI CoinText;
    public Text TimerText;
    public GameObject pause;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PauseMenu()
    {
        if (GameManager.Instance.gamePaused)
        {
            pause.SetActive(true);
        }
        else if (GameManager.Instance.gamePaused == false)
        {
            pause.SetActive(false);
        }
    }
    void Update()
    {
        // Turn on and Turn off the double jump
        if (DoubleJump == false)
        {
            doubleJumpToggle.isOn = false;
        }
    }
    public void UpdateScore(int newScore)
    {
        CoinText.text = newScore.ToString();

    }
    public void UpdateHealth(int newHealth)
    {
        LifeIndicator.SetInteger("Player_Life", newHealth);
    }
    public void UpdateTimer(string newTime)
    {
        TimerText.text = newTime;
    }
}
