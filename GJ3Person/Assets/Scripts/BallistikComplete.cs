using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistikComplete : MonoBehaviour
{
    public GameObject Bomb;
    public float ForceLaunch;
    public Transform AngleTransform;
    public float AngleInDegrees;
    private int timeshot = 0;

    // Update is called once per frame
    void Update()
    {
        if (timeshot == 1000)
        {
            timeshot = 0;
            AngleTransform.localEulerAngles = new Vector3(0f, 0f, -AngleInDegrees);
            Shoot();
        }
        else
            timeshot++;
    }

    public void Shoot()
    {
      
        AngleTransform.localEulerAngles = new Vector3(0f, 0f, -Random.Range(55f, 85f));
        GameObject BombIns = Instantiate(Bomb, AngleTransform.position, AngleTransform.rotation);
        BombIns.GetComponent<Rigidbody2D>().velocity = -AngleTransform.right * ForceLaunch;
    }
}
