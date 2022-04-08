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
    public bool HasMerged { get; private set; }

    public const int MaxValue = 5;

    [SerializeField]
    private Image image;
    [SerializeField]
    private Text points;

    private CellAnimation currentAnimation;
    public void SetValue(int x, int y, int value, bool updateUI = true)
    {
        X = x;
        Y = y;
        Value = value;

        if(updateUI)
            UpdateCell();
    }

    public void InreaseValue()
    {
        Value++;
        HasMerged = true;

       // UpdateCell();
    }

    public void ResetFlags()
    {
        HasMerged = false;
    }

    public void MergeWithCell( Cell2048 otherCell)
    {

        CellAnimationController.Instance.SmoothTransiction(this, otherCell, true);
        otherCell.InreaseValue();
        SetValue(X, Y, 0); 
        //UpdateCell();
    }
    public void MoveToCell(Cell2048 target)
    {
        CellAnimationController.Instance.SmoothTransiction(this, target, false);
        target.SetValue(target.X, target.Y, Value, false);
        SetValue(X, Y, 0);
       // UpdateCell();
    }

    public void UpdateCell()
    {
        points.text = IsEmpty ? string.Empty : Points.ToString();

        image.sprite = ImageManager.Instante.CellImages[Value];
    }


    public void SetAnimation(CellAnimation animation)
    {
        currentAnimation = animation;
    }

    public void CancelAnimation()
    {
        if (currentAnimation != null)
            currentAnimation.Desstroy();
    }
}
