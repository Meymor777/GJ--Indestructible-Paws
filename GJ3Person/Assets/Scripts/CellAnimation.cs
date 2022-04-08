using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;


public class CellAnimation : MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private Text points;

    private float moveTime = .1f;
    private float appearTime = .1f;

    private Sequence sequence;

    public void Move(Cell2048 from, Cell2048 to, bool isMerging)
    {
        from.CancelAnimation();
        to.SetAnimation(this);

        image.sprite = ImageManager.Instante.CellImages[from.Value];
        points.text = from.Points.ToString();

        transform.position = from.transform.position;

        sequence = DOTween.Sequence();

        sequence.Append(transform.DOMove(to.transform.position, moveTime).SetEase(Ease.InOutQuad));

        if(isMerging)
        {
            sequence.AppendCallback(() =>
            {
                image.sprite = ImageManager.Instante.CellImages[to.Value];
                points.text = to.Points.ToString();
            });

            sequence.Append(transform.DOScale(1500f, appearTime));
            sequence.Append(transform.DOScale(1f, appearTime));
        }

        sequence.AppendCallback(() =>
        {
            to.UpdateCell();
            Desstroy();
        });
    }

    public void Appear(Cell2048 cell)
    {
        cell.CancelAnimation();
        cell.SetAnimation(this);

        image.sprite = ImageManager.Instante.CellImages[cell.Value];
        points.text = cell.Points.ToString();

        transform.position = cell.transform.position;
        transform.localScale = Vector2.zero;

        sequence = DOTween.Sequence();

        sequence.Append(transform.DOScale(1500f, appearTime*2));
        sequence.Append(transform.DOScale(1f, appearTime*2));

        sequence.AppendCallback(() =>
        {
            cell.UpdateCell();
            Desstroy();
        });
    }    

    public void Desstroy()
    {
        sequence.Kill();
        Destroy(gameObject);
    }
}
