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
        // GameManager.Instance.gamePaused = false;
    }
    public void Sound()
    {
        SceneManager.LoadScene("SoundMenu");
        SoundController.Instance.PlayEffect(5);
    }
}
