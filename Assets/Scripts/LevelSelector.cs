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
        SceneManager.LoadScene("MainMenu");
        SoundController.Instance.PlayEffect(5);
    }
    public void Level_01()
    {
        SceneManager.LoadScene("Level_01");
        Time.timeScale = 1f;
        SoundController.Instance.PlayEffect(5);
        GameManager.Instance.inGame = true;
    }
    public void Level_02()
    {
        SceneManager.LoadScene("Level_02");
        Time.timeScale = 1f;
        SoundController.Instance.PlayEffect(5);
        GameManager.Instance.inGame = true;
    }
    public void Level_03()
    {
        SceneManager.LoadScene("Level_03");
        Time.timeScale = 1f;
        SoundController.Instance.PlayEffect(5);
        GameManager.Instance.inGame = true;
    }
}
