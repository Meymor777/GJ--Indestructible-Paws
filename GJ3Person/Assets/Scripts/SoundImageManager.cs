using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundImageManager : MonoBehaviour
{
    public static SoundImageManager Instante;

    public Sprite[] SoundButtonImages;

    private void Awake()
    {
        if (Instante == null)
            Instante = this;
    }

}
