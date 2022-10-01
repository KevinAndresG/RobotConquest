using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LosScreenMenu : MonoBehaviour
{
    [SerializeField] Image playerDestroy;
    [SerializeField] Image[] Characters;
    Image currentCharacter;
    void Start()
    {
        SoundController.Instance.Music(SceneManager.GetActiveScene().name);
        currentCharacter = Characters[PlayerPrefs.GetInt("CharacterSelected")];
        playerDestroy.sprite = currentCharacter.sprite;
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
