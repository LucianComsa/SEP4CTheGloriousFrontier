using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour {

	private int numberOfPoints = 0;
	[SerializeField]
	private int pointsPerCorrectDecission = 10;

	[SerializeField]
	private int pointsPerWrongDecission = -5;
	[HideInInspector]
	public int FinalNumberOfPoints = 0;

	[SerializeField]
	private PlayerDecisionManager PlayerDecisionManager;
	[SerializeField]
	private LevelLockManager levelManager;
	void Start () {
		PlayerDecisionManager.OnValidationDone += CalculatePoints;
	}
	private void CalculatePoints(int CorrectlyProcessed, int TotalTravelers)
	{
		numberOfPoints = CorrectlyProcessed * pointsPerCorrectDecission; 
		int wronglyProcessed =  TotalTravelers - CorrectlyProcessed;
		numberOfPoints += wronglyProcessed *pointsPerWrongDecission;
		FinalNumberOfPoints = numberOfPoints;
		levelManager.SavePointsForLevel(FinalNumberOfPoints);
	}
}
