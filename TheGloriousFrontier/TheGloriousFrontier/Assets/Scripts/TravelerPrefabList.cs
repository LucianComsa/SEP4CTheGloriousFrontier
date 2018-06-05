using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelerPrefabList : MonoBehaviour
{
	[SerializeField]
	private List<GameObject> prefabs = new List<GameObject>();

	public GameObject getByIndex(int index)
	{
		if(index >= 0 && index < prefabs.Count)
		{
			return prefabs[index];
		}else return null;
	}
	public int getSize()
	{
		return prefabs.Count;
	}


}
