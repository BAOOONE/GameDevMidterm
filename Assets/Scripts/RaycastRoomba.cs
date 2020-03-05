using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastRoomba : MonoBehaviour
{

    public float maxRayDistance;
    public float RoombaSpeed;
    
    

    // Update is called once per frame
    void Update()
    {
        // 1. ray
        Ray RoombaRay = new Ray(transform.position, transform.forward);
        
        // 2. define max raycast distance
        
        //vasualize raycast
        
        Debug.DrawRay(RoombaRay.origin, RoombaRay.direction * maxRayDistance, Color.green);
        
        // 4. shoot raycast

        if (Physics.Raycast(RoombaRay, maxRayDistance))
        {
            int randomNumber = Random.Range(0, 100);
            if (randomNumber < 50)
            {
                transform.Rotate(new Vector3(0, 90, 0 ));
            }

            if (randomNumber >= 50)
            {
                transform.Rotate(new Vector3(0, -90, 0 ));
            }
        }
        else
        {
            transform.Translate(0, 0, Time.deltaTime * RoombaSpeed);
        }
    }
}
