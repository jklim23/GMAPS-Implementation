using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationinput : MonoBehaviour
{
    public float rotationSpeed = 25f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //uses horizontal input like A and D keys
        float horizontalInput = Input.GetAxis("Horizontal");
        RotatePlayer(horizontalInput);
    }

    void RotatePlayer(float input)
    {
        //uses fomula to calculate how much to rotate and apllies it to transform.rotate component 
        float rotationAmount = input * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationAmount);
    }

}
