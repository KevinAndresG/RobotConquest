using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SoundMenu : MonoBehaviour
{
    public TMP_Dropdown musicSelector;
    void Start()
    {
        if (!PlayerPrefs.HasKey("SelectedSong"))
        {
            PlayerPrefs.SetFloat("SelectedSong", 0);
            Load();
        }
        else
            Load();
    }
    public void X()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("ActualSceneN"));
        Time.timeScale = 1f;
        GameManager.Instance.inGame = true;
        SoundController.Instance.PlayEffect(5);
    }

    public void HandleInputData()
    {
        Save();
    }
    public void Load()
    {
        musicSelector.value = PlayerPrefs.GetInt("SelectedSong");
    }
    void Save()
    {
        PlayerPrefs.SetInt("SelectedSong", musicSelector.value);
    }
}
