using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PVORocket : MonoBehaviour
{
    private int timeshot = 0;
    void Update()
    {
        if (timeshot == 200)
        {
            timeshot = 0;
            Destroy(this.gameObject);
        }
        else
            timeshot++;

    }
}
