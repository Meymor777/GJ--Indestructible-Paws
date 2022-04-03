using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PVOScanning : MonoBehaviour
{
    [SerializeField] private Camera maincamera;
    public Transform StartRay;
    public GameObject PVOShoot;

    // Update is called once per frame
    void Update()
    {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //var newPosition = StartRay.position + maincamera.ScreenToWorldPoint(Input.mousePosition) * Time.deltaTime;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, mousePosition, 6f);

            Debug.DrawRay(transform.position, mousePosition, Color.blue);
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
                //Vector2 direction = (Vector2)mousePosition - rb.position;

                //direction.Normalize();

                //float rotateAmount = Vector3.Cross(direction, PVORocket.transform.up).z;

                //rb.angularVelocity = rotateAmount * 200f;

            }
            }



    }
}
