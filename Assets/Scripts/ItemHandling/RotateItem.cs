using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItem : MonoBehaviour
{
    public float rotationSpeed = 45;
    float dragSpeed = 150;
    public bool rotationInterrupted, dragging;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        Vector3 scale = transform.localScale;
        dragSpeed *= Mathf.Max(scale.x, scale.y, scale.z);
    }

    // Update is called once per frame
    void Update()
    {
        dragging = Input.GetMouseButton(0);
        if (Input.GetMouseButtonDown(0))
            rotationInterrupted = true;
        //if (!rotationInterrupted)
          //  transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
    }

    private void FixedUpdate()
    {
        if (dragging)
        {
            //print(dragSpeed);
            float x = Input.GetAxis("Mouse X") * dragSpeed * Time.fixedDeltaTime;
            float y = Input.GetAxis("Mouse Y") * dragSpeed * Time.fixedDeltaTime;
            rb.AddTorque(Vector3.down * x);
            rb.AddTorque(Vector3.right * y);
        }
    }

}
