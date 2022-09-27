using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public static GameManager Instance;
    public bool inGame;
    public bool gamePaused = false;
    [SerializeField] int score = 0;

    public int Score
    {
        get => score;
        set
        {
            score = value;
            UIManager.Instance.UpdateScore(score);
        }
    }
    [SerializeField] GameObject spawn;
    public GameObject[] characters;
    PlayerController playerInstanciated;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        spawn = GameObject.FindGameObjectWithTag("SpawnPoint");
        if (inGame)
        {
            InstanceCharacter();
        }
        if (gamePaused)
        {
            Time.timeScale = 0f;
            // Cursor.lockState = CursorLockMode.None;
            UIManager.Instance.PauseMenu();
        }
        else if (gamePaused == false)
        {
            Time.timeScale = 1f;
            UIManager.Instance.PauseMenu();
        }
    }
    public void InstanceCharacter()
    {
        player = Instantiate(characters[PlayerPrefs.GetInt("CharacterSelected")], spawn.transform.position, Quaternion.identity);
        playerInstanciated = player.GetComponent<PlayerController>();
        playerInstanciated.StartElements();
        inGame = false;
    }
}
