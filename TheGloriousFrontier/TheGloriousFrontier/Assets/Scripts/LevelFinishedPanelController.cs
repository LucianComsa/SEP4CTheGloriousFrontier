using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelFinishedPanelController : MonoBehaviour {

	private PointsDisplayer displayer;
	[SerializeField]
	private PointsManager pointsManager;
	[SerializeField]
	private Timer timer;

	public event Action OnStartNextLevel = delegate {};
	// Use this for initialization
	void Start () {
		
		displayer = GetComponent<PointsDisplayer>();
		timer.OnLevelFinishedSetupDone += ActivatePanel;
		gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	}
	private void ActivatePanel()
	{
		gameObject.SetActive(true);
		displayer.setPointsText(pointsManager.FinalNumberOfPoints);
	}
	public void StartNextLevel() {
		OnStartNextLevel();
	//	gameObject.SetActive(false);

	}
}
