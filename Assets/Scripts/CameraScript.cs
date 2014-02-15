using UnityEngine;
using System.Collections;


public class CameraScript : MonoBehaviour {


    public Transform target;
    Vector3 speed;
    public Vector3 camOffset;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        this.transform.position = Vector3.SmoothDamp(this.transform.position + camOffset, target.position, ref speed, 0.05f);


	}
}
