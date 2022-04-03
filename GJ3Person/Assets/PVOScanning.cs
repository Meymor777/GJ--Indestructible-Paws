using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PVOScanning : MonoBehaviour
{
    [SerializeField] private Camera maincamera;
    public Transform StartRay;
    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var newPosition = StartRay.position + maincamera.ScreenToWorldPoint(Input.mousePosition) * Time.deltaTime;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, mousePosition, 3f);

        Debug.DrawRay(transform.position, mousePosition, Color.blue);
        if (hit.collider != null)
        {
            //Debug.Log("Ray has been Cast and hit an Object");
            var targetPos = hit.collider.gameObject.transform.position; //Save the position of the object mouse was over
           // Debug.Log("Target Position: " + targetPos);
            if (hit.collider.gameObject.name != "Flour" && hit.collider.gameObject.name != "Enemy" && hit.collider.gameObject.name != "PVO1" && hit.collider.gameObject.name != "PVO2")
            {
                Destroy(hit.collider.gameObject);
            }
        }

    }
}
