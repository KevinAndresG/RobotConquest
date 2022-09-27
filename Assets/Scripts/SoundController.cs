using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class SoundController : MonoBehaviour
{
    public static SoundController Instance;
    public string[] scenes;
    public string scene0;
    public string scene1;
    public string scene2;
    public string scene3;
    public string scene4;
    public string scene5;
    public string scene6;
    public AudioSource effectSource;
    public AudioSource[] menuMusic;
    public AudioSource menuSong0;
    public AudioSource menuSong1;
    public AudioSource[] musicSource;
    public AudioSource song0;
    public AudioSource song1;
    public AudioClip[] effects;
    public AudioClip effect0;
    public AudioClip effect1;
    public AudioClip effect2;
    public AudioClip effect3;
    public AudioClip effect4;
    public AudioClip effect5;
    public AudioClip effect6;
    public AudioClip effect7;
    public AudioClip effect8;
    public AudioClip effect9;
    public AudioClip effect10;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        menuMusic = new AudioSource[2];
        menuMusic[0] = menuSong0;
        menuMusic[1] = menuSong1;
        musicSource = new AudioSource[2];
        musicSource[0] = song0;
        musicSource[1] = song1;
        scenes = new string[7];
        scenes[0] = "MainMenu";
        scenes[1] = "LevelSelector";
        scenes[2] = "CharacterSelector";
        scenes[3] = "WinScreen";
        scenes[4] = "LosScreen";
        scenes[5] = "SoundMenu";
        scenes[6] = "PauseMenu";
        effects = new AudioClip[11];
        effects[0] = effect0;
        effects[1] = effect1;
        effects[2] = effect2;
        effects[3] = effect3;
        effects[4] = effect4;
        effects[5] = effect5;
        effects[6] = effect6;
        effects[7] = effect7;
        effects[8] = effect8;
        effects[9] = effect9;
        effects[10] = effect10;
    }
    void Update()
    {
    }
    public void PlayEffect(int sound)
    {
        effectSource.PlayOneShot(effects[sound]);
    }
    public void Music(string actual)
    {
        bool check = Array.Exists(scenes, x => x == actual);
        if (check)
        {
            musicSource[PlayerPrefs.GetInt("SelectedSong")].Stop();
            if (!menuMusic[PlayerPrefs.GetInt("SelectedSong")].isPlaying)
            {
                menuMusic[0].Stop();
                menuMusic[1].Stop();
                menuMusic[PlayerPrefs.GetInt("SelectedSong")].Play();
            }
        }
        else
        {
            menuMusic[PlayerPrefs.GetInt("SelectedSong")].Stop();
            musicSource[PlayerPrefs.GetInt("SelectedSong")].Play();
        }
    }
}
