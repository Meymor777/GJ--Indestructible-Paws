using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistikComplete : MonoBehaviour
{
    public GameObject Bomb;
    public Transform StartBullet;
    public Transform AngleTransform;
    private int timeshot = 0;

    void Update()
    {
        if (timeshot == 300)
        {
            timeshot = 0;
            Shoot();
        }
        else
            timeshot++;
    }

    public void Shoot()
    {
      
        AngleTransform.localEulerAngles = new Vector3(0f, 0f, -Random.Range(30f, 70f));
        GameObject BombIns = Instantiate(Bomb, StartBullet.position, AngleTransform.rotation);
        BombIns.GetComponent<Rigidbody2D>().velocity = -AngleTransform.right * 10f;
    }
}
