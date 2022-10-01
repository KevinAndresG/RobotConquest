using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreenMenu : MonoBehaviour
{
    public TextMeshProUGUI CoinText;
    public Text TimeText;
    int CoinsPerLevel;
    [SerializeField] Image playerWin;
    [SerializeField] Image[] Characters;
    Image currentCharacter;
    void Start()
    {
        CoinText.text = $"{PointsController.Instance.points}";
        CoinsPerLevel = PlayerPrefs.GetInt("CoinsPerLevel");
        PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") + CoinsPerLevel);
        CoinText.text = $"{CoinsPerLevel}";
        SoundController.Instance.Music(SceneManager.GetActiveScene().name);
        TimeText.text = $"{PlayerPrefs.GetString("Time")}";
        currentCharacter = Characters[PlayerPrefs.GetInt("CharacterSelected")];
        playerWin.sprite = currentCharacter.sprite;
    }
    public void X()
    {
        SceneManager.LoadScene("MainMenu");
        SoundController.Instance.PlayEffect(5);
    }
    public void LevelSelector()
    {
        // SoundController.Instance.audioSource[0].Stop();
        // SoundController.Instance.Music(1);
        SceneManager.LoadScene("LevelSelector");
        SoundController.Instance.PlayEffect(5);
    }
    public void NextLevel()
    {
        // SoundController.Instance.audioSource[0].Stop();
        // SoundController.Instance.Music(0);
        SceneManager.LoadScene(PlayerPrefs.GetInt("ActualScene") + 1);
        GameManager.Instance.inGame = true;
        SoundController.Instance.PlayEffect(5);
    }
}
