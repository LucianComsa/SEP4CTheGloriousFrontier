using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	//private GameObject PanelLevelFinished;
    private int RemainingTime = 0;

    [SerializeField]
	private float RemainingTimeInSeconds = 0;
	// [SerializeField]
	// private PointsDisplayer displayer;
	// [SerializeField]
	// private PointsManager pointsManager;

	private Text TimerText;
	private bool isTimerStarted;
    private bool FinishedLevel;

    public event Action OnLevelFinished = delegate {};
	public event Action OnLevelFinishedSetupDone = delegate {};
	//public event Action OnStartNextLevel = delegate {};


    void Start () 
	{
      //  PanelLevelFinished = transform.Find("LevelFinishedPanel").gameObject;
		TimerText = transform.Find("MainPanel").transform.Find("TimerText").GetComponent<Text>();
		transform.Find("RulesPanel").Find("RuleListTextBox").GetComponent<RuleListFiller>().OnRulesPanelClosed += StartTimer;
		InGameUIManager InGameUIManager = GetComponent<InGameUIManager>();
		InGameUIManager.OnPause += StopTimer;
		InGameUIManager.OnResume += StartTimer;
		RemainingTime =(int) RemainingTimeInSeconds;
	
	}
    void Update () {
		setTimerTime();
	}
	
	private void StartTimer() {
		isTimerStarted = true;
	}

	private void StopTimer() {
		isTimerStarted = false;
	}

    public void setTimerTime() {
		if (!isTimerStarted || FinishedLevel) return;

		RemainingTimeInSeconds -= Time.deltaTime;

		if (RemainingTimeInSeconds <= 1f) {
			Debug.Log("finished level");
			FinishedLevel = true;
			OnLevelFinished();
			OnLevelFinishedSetupDone();
			// displayer.setPointsText(pointsManager.FinalNumberOfPoints);
			// PanelLevelFinished.SetActive(true);
			TimerText.color = Color.red;
			return;
		}

		string minutes = String.Format("{00:00}", (int) (RemainingTimeInSeconds / 60)); 
		string seconds = String.Format("{00:00}", (RemainingTimeInSeconds % 60) - 1); 

		TimerText.text = minutes + " : " + seconds;
	}

	private void ResetRemainingTime() {
		RemainingTimeInSeconds = RemainingTime;
	}
}
