using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ArrivalScript : MonoBehaviour {

	private bool hasReached = false;
	private bool shouldRotate = true;
	private Vector3 curPos, lastPos;
	void Start () {
		
	}
	
	void Update () {
		 curPos = gameObject.transform.position;
    	if(curPos == lastPos && shouldRotate) {
			
         //GetComponent<Transform>().Rotate(0,-80,0);
		 Vector3 targetPoint = new Vector3(transform.position.x, 10, transform.position.z);
		  Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
 			float turnSpeed = 2; 
 			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
     	}
    	 lastPos = curPos;
	}

	void OnTriggerEnter(Collider other)
	{
		//Debug.Log("Reached desk " + other);
		if(!hasReached)
		{
			GetComponent<NavMeshAgent>().isStopped = true;
			GetComponent<Rigidbody>().freezeRotation = true;
			GetComponent<Movement>().shouldAnimate = false;
		}
		hasReached = true;
	}

}
