using UnityEngine;
using UnityEngine.SceneManagement;

public class LosScreenMenu : MonoBehaviour
{
    void Start()
    {
        SoundController.Instance.Music(SceneManager.GetActiveScene().name);
    }
    public void LevelSelector()
    {
        SceneManager.LoadScene("LevelSelector");
        SoundController.Instance.PlayEffect(5);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        SoundController.Instance.PlayEffect(5);
    }
    public void Restart()
    {
        // SoundController.Instance.audioSource[0].Stop();
        // SoundController.Instance.Music(0);
        SoundController.Instance.Music(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(PlayerPrefs.GetString("sceneName"));
        SoundController.Instance.PlayEffect(5);
        GameManager.Instance.inGame = true;
    }
}
