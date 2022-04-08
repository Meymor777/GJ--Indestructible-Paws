using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audio_1;
    public AudioSource audio_2;
    private AudioSource _currentMainAudio;

    public AudioClip[] clips;
    private int currentClip = 0;

    public float fadeInSec = 1f;


    private void Start()
    {
        _currentMainAudio = audio_1;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playFade();
        }
    }

    public void playFade()
    {
        StopCoroutine("playFadeCoroutine");
        StartCoroutine("playFadeCoroutine");

        if (++currentClip >= clips.Length) currentClip = 0;
    }

    private IEnumerator playFadeCoroutine()
    {
        AudioSource newMainAudio = _currentMainAudio == audio_1 ? audio_2 : audio_1;
        newMainAudio.clip = clips[currentClip];
        newMainAudio.volume = 0;
        newMainAudio.Play();

        float volume;
        while (true)
        {
            volume = 1f / fadeInSec * Time.deltaTime;

            _currentMainAudio.volume -= volume;
            newMainAudio.volume += volume;

            if (newMainAudio.volume >= 1) break;
            yield return null;
        }
        _currentMainAudio = newMainAudio;
    }

}
