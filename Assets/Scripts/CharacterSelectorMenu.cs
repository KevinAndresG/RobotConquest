using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelectorMenu : MonoBehaviour
{
    public TextMeshProUGUI CoinText;
    void Start()
    {
        CoinText.text = $"{PlayerPrefs.GetInt("TotalCoins")}";
        SoundController.Instance.Music(SceneManager.GetActiveScene().name); 
    }
    public void X()
    {
        // SoundController.Instance.audioSource[0].Stop();
        SceneManager.LoadScene("MainMenu");
        SoundController.Instance.PlayEffect(5);
    }
}
