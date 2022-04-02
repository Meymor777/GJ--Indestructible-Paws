using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigerBomb : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Flour")
        {
            OnDestroy();
        }
        else if(collision.gameObject.name == "PVORocket")
        {

        }
        else
        {
            OnDestroy();
        }

    }

    public void OnDestroy()
    {
        Destroy(this.gameObject);
    }
}
