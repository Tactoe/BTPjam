using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastItem : MonoBehaviour
{
    //public LayerMask ValidLayers;

    Camera cam;
    bool trackingPosition = true;
    private RaycastHit hitInfo;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        // Debug.DrawRay(ray.origin, ray.direction);

        if (!UIManager._instance.inMenu)
        {
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (Input.GetMouseButtonDown(0) && hitInfo.collider.tag == "Erasable")
                {
                    UIManager._instance.ActivateItemCanvas(hitInfo.collider.gameObject, hitInfo.collider.gameObject.GetComponent<ItemData>());
                    print(hitInfo.collider.gameObject.name);
                    trackingPosition = false;
                }
            }
        }
    }
}
