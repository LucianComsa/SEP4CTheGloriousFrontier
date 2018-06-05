using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelerAnimationController : MonoBehaviour {

	private Animator anim;
	// Use this for initialization
	void Start () {
		if(gameObject.GetComponent<Animator>() != null)
		{
			anim = gameObject.GetComponent<Animator>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
