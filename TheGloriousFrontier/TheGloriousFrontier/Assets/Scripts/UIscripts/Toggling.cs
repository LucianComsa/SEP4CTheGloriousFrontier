using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggling : MonoBehaviour {
	private static GameObject currentDocPanel; 

	public void ToggleVisibility(GameObject docPanel){
		if(currentDocPanel != null){
			currentDocPanel.SetActive(false);
		}

		if(currentDocPanel == null)					
			docPanel.SetActive(true);		
		else if (!docPanel.Equals(currentDocPanel))
			docPanel.SetActive(true);
		else 
			docPanel = null;

		currentDocPanel = docPanel;				
	}

}
