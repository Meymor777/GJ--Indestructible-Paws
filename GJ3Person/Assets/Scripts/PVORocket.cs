using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PVORocket : MonoBehaviour
{
    private int timeshot = 0;
    public int LifeTime = 200;
    void Update()
    {
        if (timeshot == LifeTime)
        {
            timeshot = 0;
            //Destroy(this.gameObject);
            this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.down * 5f;
        }
        else
            timeshot++;

    }
}
