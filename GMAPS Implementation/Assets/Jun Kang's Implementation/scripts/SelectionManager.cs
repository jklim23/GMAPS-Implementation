using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectionManager : MonoBehaviour
{
    public InputAction mouseclick;
    private Camera cam;
    public LayerMask clickable;
    private float MouseDragPhysicsSpeed = 10f;
    private float MouseDragSpeed = 0.1f;
    private Vector3 velocity = Vector3.zero;
    private WaitForFixedUpdate WaitForFixedUpdate = new WaitForFixedUpdate();

    private void Awake()
    {
        cam = Camera.main;
    }
    private void OnEnable()
    {
        mouseclick.Enable();
        mouseclick.performed += mousePress;

    }
    private void OnDisable()
    {
        mouseclick.Disable();
        mouseclick.performed -= mousePress;
    }
    

    private void mousePress(InputAction.CallbackContext context)
    {
        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit,Mathf.Infinity,clickable))
        {
            if(hit.collider != null)
            {
              
                StartCoroutine(DragUpdate(hit.collider.gameObject));
            }
            
        }
    }
    private IEnumerator DragUpdate(GameObject gameObject)
    {
        float originalDistance = Vector3.Distance(gameObject.transform.position, cam.transform.position);
        gameObject.TryGetComponent<Rigidbody>(out var rb);
        while (mouseclick.ReadValue<float>() != 0)
        {
            Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
            if(rb != null)
            {
                Vector3 direction = ray.GetPoint(originalDistance) - gameObject.transform.position;
                rb.velocity = direction * MouseDragPhysicsSpeed;
                
                yield return WaitForFixedUpdate;
            }
            else
            {
                gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, ray.GetPoint(originalDistance),ref velocity, MouseDragSpeed);
                
                yield return null;
            }
        }
    }
   
}
