using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lr_LineReader : MonoBehaviour
{
    private LineRenderer lr;
    public Transform points;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
 
        lr.SetPosition(0, points.position);
        lr.SetPosition(1, Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
}
