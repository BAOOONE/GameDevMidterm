using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMovement : MonoBehaviour
{ 
    
    public Rigidbody thisRigidbody;
   public float speed = 10f;
   //public float forwardBackward;
   public bool forwardOrBackward = true;
   public float score = 100f;
   public bool spacePressed;
   public float wheelRotation = 0;
   private bool rotated = false;
   
   
   public Vector3 rotationValue;
  
   
   public Material green;
   public Material gray;
   public Text gear;
   public Text scoreText;
   
   
   
    // Start is called before the first frame update
    void Start()
    {
        //thisRigidbody = GetComponent<Rigidbody>();
        GetComponent<MeshRenderer> ().material = gray;
        gear.GetComponent<Text>();
        gear.text="- ";
        score = 100f;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            forwardOrBackward = true;

        }
        if (Input.GetKey(KeyCode.S))
        {
            forwardOrBackward = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacePressed = true;
            rotationValue = transform.eulerAngles;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            spacePressed = false;
            
        }
        
       

        if (spacePressed == true)
        {
            
            
            
            if (rotated == false)
            {
                if (Math.Abs(transform.eulerAngles.y - (rotationValue.y + wheelRotation)) > 0.1)
                {
                    transform.Rotate(new Vector3(0, -1, 0));
                }
                else
                {
                    Debug.Log("out");
                    rotated = true;
                }
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(new Vector3(0, -1, 0));
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(new Vector3(0, 1, 0));
            }
        }
        else
        {
            rotated = false;
            if (Input.GetKey(KeyCode.A))
            {
                wheelRotation--;
            }
            if (Input.GetKey(KeyCode.D))
            {
                wheelRotation++;
            }
        }

    }
    
    void OnCollisionEnter (Collision target)
    {
        if( target.gameObject.tag.Equals("obstacle") == true ){
            score -= 1;
            scoreText.text = "Score: " + score;

            // Debug.Log("llllll");
        }
        
    }
    
    private void FixedUpdate()
    {
        if (forwardOrBackward == true)
        {
            gear.text="Forward ";  
            GetComponent<MeshRenderer> ().material = green;
            if (spacePressed)
            {
                thisRigidbody.AddForce(transform.forward  * speed, ForceMode.Impulse);

            }
        }
        if (forwardOrBackward == false)
        {
            gear.text="Backward ";
            GetComponent<MeshRenderer> ().material = gray;
            if (spacePressed)
            {
                thisRigidbody.AddForce(transform.forward  * -speed, ForceMode.Impulse);

            }
        }
       
        
        //thisRigidbody.AddTorque(new Vector3(0, rightLeft * rotationSpeed, 0), ForceMode.Impulse);
        
        
    }
}
