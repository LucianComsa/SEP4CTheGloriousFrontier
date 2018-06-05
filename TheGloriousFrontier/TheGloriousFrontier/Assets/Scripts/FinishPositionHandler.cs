using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class FinishPositionHandler : MonoBehaviour {

	// Use this for initialization
	public event Action OnTravelerFinished = delegate {};
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) 
	{
		if(other.gameObject.tag.ToLower().Equals("traveler"))
		{
			OnTravelerFinished();
		}
    }
}
