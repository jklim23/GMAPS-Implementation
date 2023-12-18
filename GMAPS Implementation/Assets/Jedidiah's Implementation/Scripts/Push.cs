using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider != null)
                {
                    Vector3 direction = (hit.transform.position - hit.point).normalized;
                    hit.rigidbody.AddTorque(new Vector3(-direction.y * hit.transform.localScale.y * 2.5f, direction.x * hit.transform.localScale.x * 5f, 0f), ForceMode.Force);
                    hit.rigidbody.AddForce(direction * 10f, ForceMode.Force);
                }
            }
        }
    }
}
