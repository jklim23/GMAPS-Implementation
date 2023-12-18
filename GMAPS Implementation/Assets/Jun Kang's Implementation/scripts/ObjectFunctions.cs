using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectFunctions : MonoBehaviour
{
    public bool IsSizeable;
    public Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        IsSizeable = true;
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IsSizableFalse()
    {
        IsSizeable=false;
    }
    public void IsSizableTrue()
    {
        IsSizeable=true;
    }
}
