using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell2048 : MonoBehaviour
{
    public int X { get; private set; }

    public int Y { get; private set; }

    public int Value { get; private set; }

    public int Points => IsEmpty ? 0 : (int)Mathf.Pow(2, Value);

    public bool IsEmpty => Value == 0 ;

    public const int MaxValue = 4;

    [SerializeField]
    private Image image;
    [SerializeField]
    private Text points;

    public void SetValue(int x, int y, int value)
    {
        X = x;
        Y = y;
        Value = value;

        UpdateCell();
    }

    public void UpdateCell()
    {
        points.text = IsEmpty ? string.Empty : Points.ToString();

        image.sprite = ImageManager.Instante.CellImages[Value];
    }
}
