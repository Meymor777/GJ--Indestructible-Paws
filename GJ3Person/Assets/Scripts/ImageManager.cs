using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{
    public static ImageManager Instante;

    public Sprite[] CellImages;

    private void Awake()
    {
        if (Instante == null)
            Instante = this;
    }

}
