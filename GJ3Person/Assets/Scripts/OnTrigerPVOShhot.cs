using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigerPVOShhot : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.name.Contains("PVOShoot"))
        {
            Destroy(this.gameObject);
        }
    }
}
