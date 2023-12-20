using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    Camera cam;

    // Place this script into the camera because the mouse position is relative to the camera position
    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        // Check if left click is being held
        if (Input.GetMouseButton(0))
        {
            // Create a ray and check if the raycast hits any object
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // If it hits an object then modify it's transform
                if (hit.collider != null)
                {
                    Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);

                    // Get which part did the raycast hit in relative to the object's origin
                    Vector3 direction = (hit.transform.position - hit.point).normalized;

                    // Spin the object using AddTorque
                    // Use object scale as the larger the object the further the mouse needs to be from the center of origin to achieve the same effect as a small object
                    // Flip the x and y component of the hit point to the Vector3 for AddTorque, as the horizontal rotation is on the Y axis and the vertical rotation is on the X axis
                    hit.rigidbody.AddTorque(new Vector3(-direction.y * hit.transform.localScale.y * 2.5f, direction.x * hit.transform.localScale.x * 10f, 0f), ForceMode.Force);

                    // Push the object in the direction of the hit point in relative to the object's origin
                    // So if the left side is clicked it would move slightly to the right
                    hit.rigidbody.AddForce(direction * 10f, ForceMode.Force);
                }
            }
        }
    }
}
