using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider SFXSlider;
    void Start()
    {
        if (!PlayerPrefs.HasKey("MusicVolumeLevel"))
        {
            PlayerPrefs.SetFloat("MusicVolumeLevel", 0.5f);
            LoadM();
        }
        else
            LoadM();
        if (!PlayerPrefs.HasKey("SFXvolumeLevel"))
        {
            PlayerPrefs.SetFloat("SFXvolumeLevel", 0.5f);
            LoadS();
        }
        else
            LoadS();
    }
    public void MusicVolumeLevel()
    {
        SoundController.Instance.musicSource[0].volume = musicSlider.value;
        SoundController.Instance.musicSource[1].volume = musicSlider.value;
        SoundController.Instance.menuMusic[0].volume = musicSlider.value;
        SoundController.Instance.menuMusic[1].volume = musicSlider.value;
        SaveM();
    }
    public void SFXVolumeLevel()
    {
        SoundController.Instance.effectSource.volume = SFXSlider.value;
        SaveS();
    }
    public void LoadM()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolumeLevel");
    }
    public void LoadS()
    {
        SFXSlider.value = PlayerPrefs.GetFloat("SFXvolumeLevel");
    }
    void SaveM()
    {
        PlayerPrefs.SetFloat("MusicVolumeLevel", musicSlider.value);
    }
    void SaveS()
    {
        PlayerPrefs.SetFloat("SFXvolumeLevel", SFXSlider.value);
    }
}
