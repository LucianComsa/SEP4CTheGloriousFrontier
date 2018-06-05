using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameUIManager : MonoBehaviour {
	
	[SerializeField]
	private GameObject PanelPause, PanelMain, PanelAcceptReject, PanelLevelFinished;

	private GameObject OpenDocsBtn;

	public event Action<bool> OnDecissionDetected = delegate {};
	public event Action OnPause = delegate {};
	public event Action OnResume = delegate {};

	[SerializeField]
	private TravelerArrivalInterraction travelerArrival;

	void Start () 
	{
		OpenDocsBtn = transform.Find("MainPanel").transform.Find("OpenDocsBtn").gameObject;

		Timer timer = GetComponent<Timer>();
		//timer.OnLevelFinished += OnRej;

		PanelPause.SetActive(false);
		PanelLevelFinished.SetActive(false);
		PanelMain.SetActive(true);
		PanelAcceptReject.SetActive(false);
		travelerArrival.OnTravelerArrival += ActivateAcceptReject; 
		travelerArrival.OnTravelerArrival += ShowOpenDocsBtn;
		OnDecissionDetected += HideOpenDocsBtn;
	}
	
	public void OpenPause()
	{
		PanelPause.SetActive(true);
		PanelMain.SetActive(false);
		OnPause();
	}

	public void ClosePause()
	{
		PanelPause.SetActive(false);
		PanelMain.SetActive(true);
		OnResume();
	}

	private void ActivateAcceptReject()
	{
		PanelAcceptReject.SetActive(true);
	}
    private void DeactivateAcceptReject()
	{
		PanelAcceptReject.SetActive(false);
	}
	private void OnApp()
	{
		OnDecissionDetected(true);
		DeactivateAcceptReject();
	}
	private void OnRej()
	{
		OnDecissionDetected(false);
		DeactivateAcceptReject();
	}

	private void ShowOpenDocsBtn(){
		OpenDocsBtn.SetActive(true);
	}

	private void HideOpenDocsBtn(bool v){
		OpenDocsBtn.SetActive(false);
	}
	public void OpenScene(string scene)
	{
		SceneManager.LoadScene(scene);
	}

}