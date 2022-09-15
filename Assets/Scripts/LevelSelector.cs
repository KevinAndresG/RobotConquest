using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    void Start()
    {
        SoundController.Instance.Music(SceneManager.GetActiveScene().name);
    }
    public void X()
    {
        // SoundController.Instance.audioSource[0].Stop();
        SceneManager.LoadScene("MainMenu");
        SoundController.Instance.PlayEffect(5);
    }
    public void Level_01()
    {
        // SoundController.Instance.audioSource[0].Stop();
        // SoundController.Instance.Music(0);
        // SoundController.Instance.Music(SceneManager.GetActiveScene());
        SceneManager.LoadScene("Level_01");
        // SoundController.Instance.Music("Level_01");
        Time.timeScale = 1f;
        SoundController.Instance.PlayEffect(5);
    }
    public void Level_02()
    {
        // SoundController.Instance.audioSource[0].Stop();
        // SoundController.Instance.Music(0);
        // SoundController.Instance.Music(SceneManager.GetActiveScene());
        SceneManager.LoadScene("Level_02");
        Time.timeScale = 1f;
        SoundController.Instance.PlayEffect(5);
    }
    public void Level_03()
    {
        // SoundController.Instance.audioSource[0].Stop();
        // SoundController.Instance.Music(0);
        // SoundController.Instance.Music(SceneManager.GetActiveScene());
        SceneManager.LoadScene("Level_03");
        Time.timeScale = 1f;
        SoundController.Instance.PlayEffect(5);
    }
}
