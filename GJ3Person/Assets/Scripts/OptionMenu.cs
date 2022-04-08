using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class OptionMenu : MonoBehaviour
{
    public AudioMixer audiomixer;
    [SerializeField]
    private Image image;
    private AudioSource AudioMenu;
    [Header("Tags")]
    [SerializeField] private string createTag;

    public static readonly string FirstPlay = "FirstPlay";
    public static readonly string MusicPref = "MusicPref";
    public static readonly string MutePref = "MutePref";
    private int firstPlayInt;
    public Slider musicSlider;
    private float musicFloat;
    public Text textButtonMute;
    private int soundismute;




    private void Start()
    {

        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        if (firstPlayInt == 0)
        {
            musicFloat = 0.75f;
            musicSlider.value = musicFloat;
            soundismute = 0;
            textButtonMute.text = soundismute.ToString();
            image.sprite = SoundImageManager.Instante.SoundButtonImages[soundismute];
            PlayerPrefs.SetInt(MutePref, soundismute);
            PlayerPrefs.SetFloat(MusicPref, musicFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);

        }
        else
        {
            musicFloat = PlayerPrefs.GetFloat(MusicPref);
            musicSlider.value = musicFloat;
            soundismute = PlayerPrefs.GetInt(MutePref);
            textButtonMute.text = soundismute.ToString();
            UpdateSound();
        }
    }

    public void SaveSoundSetting()
    {
        PlayerPrefs.SetFloat(MusicPref, musicSlider.value);
        PlayerPrefs.Save();
    }

    private void OnApplicationFocus(bool focus)
    {
        if(!focus)
        {
            SaveSoundSetting();
        }
    }

    public void UpdateSound()
    {
        AudioSource AudioMenu = GameObject.FindWithTag(this.createTag).GetComponent<AudioSource>();
        AudioMenu.volume = musicSlider.value;
        if (soundismute == 0)
        {
            AudioMenu.mute = false;
        }
        else
        {
            AudioMenu.mute = true;
        }
        image.sprite = SoundImageManager.Instante.SoundButtonImages[soundismute];
    }


    public void SetVolume(float volume)
    {
        AudioSource AudioMenu = GameObject.FindWithTag(this.createTag).GetComponent<AudioSource>();
        AudioMenu.volume = volume;    //.SetFloat("volume", Mathf.Log10(volume) * 20);
        SaveSoundSetting();
    }


    public void Sound()
    {
        AudioSource AudioMenu = GameObject.FindWithTag(this.createTag).GetComponent<AudioSource>();
        AudioMenu.mute = !AudioMenu.mute;
        if (AudioMenu.mute)
        {
            PlayerPrefs.SetInt(MutePref, 1);
            PlayerPrefs.Save();
            soundismute = 1;
        }
        else
        {
            PlayerPrefs.SetInt(MutePref, 0);
            PlayerPrefs.Save();
            soundismute = 0;
        }
        textButtonMute.text = soundismute.ToString();
        image.sprite = SoundImageManager.Instante.SoundButtonImages[soundismute];

    }
}
