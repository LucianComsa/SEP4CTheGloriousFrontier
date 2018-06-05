using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelerArrivalInterraction : MonoBehaviour {
	public event Action OnTravelerArrival = delegate{};
	public event Action<GameObject> OnTravelerCaptured = delegate {};
    public event Action OnTravelerLeft = delegate { };
	
	//this field is used to make sure that the same NPC does not "arrive" at the desk twice. 
	//This is done to overcome the glitchy mix of humanoids agents and navigation that we have.
	private GameObject last;
    void Start () {
		last = gameObject;
	}
	void Update () {
	}

	void OnTriggerEnter(Collider other) 
	{
		if(other.gameObject.tag.ToLower().Equals("traveler") && last != other.gameObject)
		{
			OnTravelerArrival();
			//Debug.Log(other.gameObject.tag);
			OnTravelerCaptured(other.gameObject);
		}
    }
     void OnTriggerExit(Collider other)
     {
         if(other.gameObject.tag.ToLower().Equals("traveler"))

         {
            OnTravelerLeft();
			last = other.gameObject;
         }
     }
}
