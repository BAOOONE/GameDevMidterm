using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastMouse : MonoBehaviour
{

    public float maxRaycastDistance;
    public GameObject paintBrush;
   
    void Update()
    {
        //define ray
        //screen point to ray
        
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        // max raycast distance
        
        // visualize the raycast
        Debug.DrawRay(camRay.origin, camRay.direction *maxRaycastDistance, Color.cyan);

        // detecting object with ray

        RaycastHit hitObject;
        if (Physics.Raycast(camRay, out hitObject, maxRaycastDistance))
        {
            //if(hitObject.collider.tag == "name"){}
            // when hit, spwan sth useful
            paintBrush.transform.position = hitObject.point;

            if (Input.GetMouseButton(0))
            {
               GameObject paint =  Instantiate(paintBrush, hitObject.point, Quaternion.identity);
               paint.transform.SetParent(hitObject.transform);
            }
        }
        
        hitObject.transform.Rotate(new Vector3(0, 0, 35*Time.deltaTime));

    }
}
