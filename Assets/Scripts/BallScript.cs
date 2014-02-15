using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BallScript : MonoBehaviour {



    Vector3 basePosition;
    float velocity;
    float initVel = 0;
    float speed = 1;
    float power = 0;
    Vector3 gravity;
    bool throwBall = false;
    Vector3 ballDirection;
    Vector3 goingBall;
    bool gravityOn = true;
    Vector3 destination;
    public float windForce = 35.0f;

	// Use this for initialization
	void Start () {
        basePosition = this.transform.position;
        gravity = new Vector3(0, -2.0f, 0);
        ballDirection = new Vector3 (0,0,0);
        destination = new Vector3(0, 1, 0.3f);
	}
	
	// Update is called once per frame
	void Update () {
	

        if(Input.GetMouseButton(0)){
            if (power <= 3.0f)
            {
                power += 0.03f;
            }
      
        }

        if (Input.GetMouseButtonUp(0)) {
            gravityOn = true;
            throwBall = true;
        }


        if (throwBall) 
        {
            gravityOn = true;
            goingBall += destination * power * Time.deltaTime;

            
                destination += gravity * Time.deltaTime;
                goingBall += ballDirection * Time.deltaTime;
                this.transform.position += goingBall;
        }





      

       


        if (Input.GetKey(KeyCode.A)) {
            ballDirection += new Vector3(-1, 0, 0) * Time.deltaTime * 0.05F;
            }

        if (Input.GetKey(KeyCode.D)) {
            ballDirection += new Vector3(1, 0, 0) * Time.deltaTime * 0.05F;
        }


        if (Input.GetKeyDown(KeyCode.R)) 
        {
            gravityOn = false;
            throwBall = false;
            this.transform.position = basePosition;
            power = 0.0f;
            destination = new Vector3(0, 1, 0.3f);
            goingBall = Vector3.zero;
            //rigidbody.velocity = Vector3.zero;
            ballDirection = Vector3.zero;
        }
	}


    void OnTriggerEnter(Collider hit) 
    {
        if (hit.gameObject.collider.CompareTag("Floor"))
        {
            gravityOn = false;
            throwBall = false;
            power = 0;
            destination = new Vector3(0, 1, 0.3f);
            goingBall = Vector3.zero;
            ballDirection = Vector3.zero;
        }


        if (hit.gameObject.collider.CompareTag("Wind")) {
            destination += hit.transform.forward * windForce * Time.deltaTime;
        }
    }



    void OnGUI() 
    {
        GUI.Label(new Rect(10,10,550,50),"Power : " + power.ToString() + "   MOUSE CLICK TO POWER!!");
        GUI.Label(new Rect(10, 30, 150, 50), "Direction: x: " + ballDirection.x.ToString());
        GUI.Label(new Rect(10, 60, 150, 50), "Vector : " + goingBall.normalized);
    }


}


   