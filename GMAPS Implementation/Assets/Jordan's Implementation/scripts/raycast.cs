using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{
    float maxScale = 1.5f;
    float Distance = 30f;
    bool Scaling = false;

    // Update is called once per frame
    void Update()
    {   // Creates a ray from the position pointing forward to detect anything within the ray distance
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit[] hits = Physics.RaycastAll(ray, Distance);

        Debug.DrawRay(ray.origin, ray.direction * Distance, Color.red);

        // does function when raycast hit
        foreach (RaycastHit hit in hits)
        {
            if (hit.transform.gameObject.layer == 7)//checks for layer of obejct that it hits
            {
                Scaling = true;
                ScaleObject(hit.transform.gameObject, Scaling);
                Renderer renderer = hit.transform.GetComponent<Renderer>();//gets render compoennt 
                if (renderer != null)
                {
                    renderer.material.color = Color.red;
                }
            }
            else if (hit.transform.gameObject.layer == 8)
            {
                Renderer renderer = hit.transform.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material.color = Color.green;
                }
            }
        }
    }

    void ScaleObject(GameObject obj, bool shouldScale)
    {
        if (shouldScale)
        {
            // increasing scale of the object hit
            obj.transform.localScale = Vector3.one * maxScale;
        }
    }
}
