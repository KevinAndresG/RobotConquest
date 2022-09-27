<<<<<<< HEAD
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // PlayerPrefs.SetString("ActualSceneN", SceneManager.GetActiveScene().name);
            if (GameManager.Instance.gamePaused)
                Resume();
            else
                Pause();
        }
    }
    public void Pause()
    {
        // SoundController.Instance.audioSource[0].Stop();
        // SoundController.Instance.Music(1);
        PlayerPrefs.SetInt("ActualScene", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetString("ActualSceneN", SceneManager.GetActiveScene().name);
        SoundController.Instance.Music("PauseMenu");
        GameManager.Instance.gamePaused = true;
        SoundController.Instance.PlayEffect(5);
    }
    public void Resume()
    {
        // SoundController.Instance.audioSource[0].Stop();
        // SoundController.Instance.Music(0);
        SoundController.Instance.Music(PlayerPrefs.GetString("ActualSceneN"));
        GameManager.Instance.gamePaused = false;
        SoundController.Instance.PlayEffect(5);
    }
    public void Restart()
    {
        // SoundController.Instance.audioSource[0].Stop();
        // SoundController.Instance.Music(0);
        SoundController.Instance.Music(PlayerPrefs.GetString("ActualSceneN"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameManager.Instance.inGame = true;
        GameManager.Instance.gamePaused = false;
        SoundController.Instance.PlayEffect(5);
    }
    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
        SoundController.Instance.PlayEffect(5);
        GameManager.Instance.gamePaused = false;
    }
    public void Sound()
    {
        SceneManager.LoadScene("SoundMenu");
        SoundController.Instance.PlayEffect(5);
    }
}
=======
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool gamePaused;
    public Canvas pause;
    void Start()
    {
        gamePaused = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // PlayerPrefs.SetString("ActualSceneN", SceneManager.GetActiveScene().name);
            if (gamePaused)
                Resume();
            else
                Pause();
        }
    }
    public void Pause()
    {
        // SoundController.Instance.audioSource[0].Stop();
        // SoundController.Instance.Music(1);
        PlayerPrefs.SetInt("ActualScene", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetString("ActualSceneN", SceneManager.GetActiveScene().name);
        SoundController.Instance.Music("PauseMenu");
        gamePaused = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        pause.gameObject.SetActive(true);
        SoundController.Instance.PlayEffect(5);
    }
    public void Resume()
    {
        // SoundController.Instance.audioSource[0].Stop();
        // SoundController.Instance.Music(0);
        SoundController.Instance.Music(PlayerPrefs.GetString("ActualSceneN"));
        gamePaused = false;
        Time.timeScale = 1f;
        pause.gameObject.SetActive(false);
        SoundController.Instance.PlayEffect(5);
    }
    public void Restart()
    {
        // SoundController.Instance.audioSource[0].Stop();
        // SoundController.Instance.Music(0);
        SoundController.Instance.Music(PlayerPrefs.GetString("ActualSceneN"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        SoundController.Instance.PlayEffect(5);
    }
    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
        SoundController.Instance.PlayEffect(5);
    }
    public void Sound()
    {
        SceneManager.LoadScene("SoundMenu");
        SoundController.Instance.PlayEffect(5);
    }
}
>>>>>>> e8f6f2b6ea5befabd076fc362c0eb3f54ed2202b
