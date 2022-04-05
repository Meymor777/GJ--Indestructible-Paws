using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PVOScanning : MonoBehaviour
{
    [SerializeField] private Camera maincamera;
    public Transform AngleGun;
    public Transform StartRay;
    public GameObject PVOShoot;

    // Update is called once per frame
    void Update()
    {

        //Mouse Position in the world. It's important to give it some distance from the camera. 
        //If the screen point is calculated right from the exact position of the camera, then it will
        //just return the exact same position as the camera, which is no good.
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);

        //Angle between mouse and this object
        float angle = AngleBetweenPoints(AngleGun.position, mouseWorldPosition);

        //Ta daa
        AngleGun.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 200f));


        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //var newPosition = StartRay.position + maincamera.ScreenToWorldPoint(Input.mousePosition) * Time.deltaTime;
            RaycastHit2D hit = Physics2D.Raycast(StartRay.position, mousePosition, 2f);

            Debug.DrawRay(StartRay.position, mousePosition, Color.blue);
            if (hit.collider != null)
            {
                //Debug.Log("Ray has been Cast and hit an Object");
                var Bomb = hit.collider.gameObject; 

                if (hit.collider.gameObject.name != "Flour" && hit.collider.gameObject.name != "Enemy" && hit.collider.gameObject.name != "PVO1" && hit.collider.gameObject.name != "PVO2" && !hit.collider.gameObject.name.Contains("PVOShoot"))
                {
                   // Debug.Log("Target Position: " + hit.collider.gameObject.name);
                   GameObject PVORocket = Instantiate(PVOShoot, StartRay.position, Quaternion.identity);
                var rb = PVORocket.GetComponent<Rigidbody2D>();
                rb.velocity = mousePosition * 6f;
                PVORocket.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 200f));
            }
            }
    }

    public float AngleBetweenPoints(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

}
