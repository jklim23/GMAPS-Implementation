using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MouseClick : MonoBehaviour
{
    private LayerMask clickable;
    Camera cam;
    public Material hoverMaterial, cantHoverMaterial,originalMaterial;



    // Start is called before the first frame update
    void Start()
    {
        clickable = LayerMask.GetMask("clickable");
        cam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        DrawRay();
        OnMouseClick();


    }
    private void DrawRay()
    {
        //draw ray from camera to the mouse position in scene
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 100f;
        mousePosition = cam.ScreenToWorldPoint(mousePosition);
        Debug.DrawRay(transform.position, mousePosition - transform.position, Color.black);
    }

    private void OnMouseClick()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //on mouse down get back the object name
        if (Input.GetMouseButtonDown(0))
        {

            if (Physics.Raycast(ray, out hit, 100, clickable))
            {
                if (hit.transform.GetComponent<objectFunctions>().IsSizeable)
                {

                    Debug.Log(hit.transform.name);
                    hit.transform.GetComponent<Renderer>().material = hoverMaterial;//change material color
                    hit.transform.GetComponent<objectFunctions>().IsSizableFalse();//set bool to false
                    Vector3 hitScale = hit.transform.GetComponent<objectFunctions>().scale;//set the scale of the object to a variable
                    hit.transform.localScale = new Vector3(hitScale.x * 2, hitScale.y * 2, hitScale.z * 2);//change object scale
                }
                else
                {
                    hit.transform.GetComponent<Renderer>().material = cantHoverMaterial;//change material color
                    hit.transform.GetComponent<objectFunctions>().IsSizableTrue();//set bool to true
                    Vector3 hitScale = hit.transform.GetComponent<objectFunctions>().scale;//set the scale of the object to a variable
                    hit.transform.localScale = new Vector3(hitScale.x,hitScale.y,hitScale.z);//change object scale
                }

            }
        }
        else if (Input.GetMouseButtonUp(0))
        {

            if (Physics.Raycast(ray, out hit, 100, clickable))
            {
                hit.transform.GetComponent<Renderer>().material = originalMaterial;
            }
            
        }

    }
}

