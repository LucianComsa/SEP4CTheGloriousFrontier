using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsDisplayer : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	private Text pointsText;
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
	public void setPointsText (int points)
	{
		if(points <= 0)
		{
			pointsText.text = "You got "+ points +" points! \n Try again! \n It improves your memory!";
		}else
		{
			pointsText.text = "Congratulations! You got "+ points +" points!";
		}
	}
}
