using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreenMenu : MonoBehaviour
{
    public TextMeshProUGUI CoinText;
    int CoinsPerLevel;
    void Start()
    {
        CoinText.text = $"{PointsController.Instance.points}";
        CoinsPerLevel = PlayerPrefs.GetInt("CoinsPerLevel");
        PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") + CoinsPerLevel);
        CoinText.text = $"{CoinsPerLevel}";
        SoundController.Instance.Music(SceneManager.GetActiveScene().name);
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
        SoundController.Instance.PlayEffect(5);
    }
}
