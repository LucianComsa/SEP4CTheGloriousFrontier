using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelerGenerator : MonoBehaviour 
{
	private TravelerPrefabList travelers;
	private int lastChosen = -1;
	// Use this for initialization
	void Start () {
		if(gameObject.GetComponent<TravelerPrefabList>() != null)
		{
			travelers = gameObject.GetComponent<TravelerPrefabList>();
		}
		
	}
	public GameObject getRandomPrefab()
	{
		int min = 0;
		int max = travelers.getSize();
		int random = Random.Range(min,max);
		if(lastChosen != -1)
		{
			while(random == lastChosen)
			{
				random = Random.Range(min,max);
			}
		}
		lastChosen = random;
		GameObject travelerPrefab = travelers.getByIndex(random);
		return travelerPrefab;
	}
}
