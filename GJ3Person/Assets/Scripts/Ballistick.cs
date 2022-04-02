using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballistick : MonoBehaviour
{

    public Transform SpawnTransform;
    public Transform AngleTransform;
    public float AngleInDegrees;
    public GameObject Bomb;
    private int timeshot = 0;
    public float ForceLaunch;

    // Update is called once per frame
    void Update()
    {

        if (timeshot == 1)
        {
            timeshot = 0;
            AngleTransform.localEulerAngles = new Vector3(0f, 0f, -AngleInDegrees);
            Shot();
        }
        else
            timeshot++;
    }

    void Shot()
    {
        // Vector3 FromTo = TargetTransform.position - transform.position;
        // Vector3 FromToXY = new Vector3(FromTo.y, 0f, FromTo.z);
        //Vector2 FromTo = new Vector3(TargetTransform.position.x - transform.position.x, 0.11f);


        //float x = FromTo.magnitude;
        //float y = FromTo.y;

        //float AngleInRadian = AngleInDegrees * Mathf.PI / 180;
        //float v2 = (g * x * x) / (2 * (y - Mathf.Tan(AngleInRadian) * x) * Mathf.Pow(Mathf.Cos(AngleInRadian), 2));

        //float v = Mathf.Sqrt(Mathf.Abs(v2));

        //GameObject newbomb = Instantiate(Bombs, SpawnTransform.position, Quaternion.identity);
        //newbomb.GetComponent<Rigidbody>().velocity = SpawnTransform.position * v/100;
        GameObject BombIns = Instantiate(Bomb, SpawnTransform.position, transform.rotation);
        BombIns.GetComponent<Rigidbody2D>().velocity = -transform.right * ForceLaunch;
    }
}
