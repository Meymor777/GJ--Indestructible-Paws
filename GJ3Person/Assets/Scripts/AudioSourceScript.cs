using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceScript : MonoBehaviour
{
    [Header("Tags")]
    [SerializeField] private string createTag;
    public AudioSource AudioMenu;
    public AudioClip[] clips;
    private int prevsound;

    private void Awake()
    {
        GameObject obj = GameObject.FindWithTag(this.createTag);
        if(obj!=null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            this.gameObject.tag = this.createTag;
            DontDestroyOnLoad(this.gameObject);
        }
      
    }
    private void Start()
    {
        prevsound = Random.Range(0, clips.Length);
        AudioMenu.clip = clips[prevsound];
        AudioMenu.Play();
    }
    private void Update()
    {
        if (!AudioMenu.isPlaying)
        {
            if (clips.Length != 1)
            {
                int newsound = prevsound;

                while (prevsound == newsound)
                    newsound = Random.Range(0, clips.Length);

                prevsound = newsound;
                AudioMenu.clip = clips[prevsound];
                AudioMenu.Play();
            }
            else
            {
                AudioMenu.clip = clips[prevsound];
                AudioMenu.Play();
            }

        }
    }
}
