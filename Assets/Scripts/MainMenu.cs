using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI CoinText;
    void Awake()
    {
        if (!PlayerPrefs.HasKey("MusicVolumeLevel"))
        {
            PlayerPrefs.SetFloat("MusicVolumeLevel", 0.5f);
        }
        if (!PlayerPrefs.HasKey("SFXvolumeLevel"))
        {
            PlayerPrefs.SetFloat("SFXvolumeLevel", 0.5f);
        }
        SoundController.Instance.effectSource.volume = PlayerPrefs.GetFloat("SFXvolumeLevel");
        SoundController.Instance.musicSource[0].volume = PlayerPrefs.GetFloat("MusicVolumeLevel");
        SoundController.Instance.musicSource[1].volume = PlayerPrefs.GetFloat("MusicVolumeLevel");
        SoundController.Instance.menuMusic[0].volume = PlayerPrefs.GetFloat("MusicVolumeLevel");
        SoundController.Instance.menuMusic[1].volume = PlayerPrefs.GetFloat("MusicVolumeLevel");
    }
    void Start()
    {
        // SoundController.Instance.musicSource.Play();
        CoinText.text = $"{PlayerPrefs.GetInt("TotalCoins")}";
        SoundController.Instance.Music(SceneManager.GetActiveScene().name);
        if (!PlayerPrefs.HasKey("SelectedSong"))
        {
            PlayerPrefs.SetInt("SelectedSong", 0);
        }
    }
    void Update()
    {
    }
    public void Play()
    {
        SceneManager.LoadScene("LevelSelector");
        SoundController.Instance.PlayEffect(5);
    }
    public void CharacterSelector()
    {
        SceneManager.LoadScene("CharacterSelector");
        SoundController.Instance.PlayEffect(5);
    }
    public void Sound()
    {
        PlayerPrefs.SetString("ActualSceneN", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("SoundMenu");
        SoundController.Instance.PlayEffect(5);
    }
    public void Exit()
    {
        Debug.Log("Exited");
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
        SoundController.Instance.PlayEffect(5);
    }
}
