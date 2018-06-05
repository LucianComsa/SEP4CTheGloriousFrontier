using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerDecisionManager : MonoBehaviour {
	// [SerializeField]
	// private GameObject TravelerManager;
	// private TravelerGeneratorManager TravelerGenerator;

	[SerializeField]
	private TravelerArrivalInterraction TravelerDetector;
	[SerializeField]
	private InGameUIManager InputFeeder;
	private ValidationManager _ValidationManager;
	private GameObject CurrentTraveler;
	private List<DocumentsFile> TravelersDocuments;

    public event Action<bool, GameObject> OnDecisionMade = delegate { };
	public event Action<int, int> OnValidationDone = delegate {};
	public event Action<bool> DecisionSoundEvent = delegate{};
	[SerializeField]
	private Timer timer;

	// Use this for initialization
	void Start () {
		_ValidationManager = new ValidationManager(CurrentGameInfo.CurrentLevel);
		TravelersDocuments = new List<DocumentsFile>();
		TravelerDetector.OnTravelerCaptured += TakeTraveler;
		InputFeeder.OnDecissionDetected += setDecision;
		timer.OnLevelFinished += performValidation;
	//	TravelerGenerator.getNextGenerated();
	}
	
	// Update is called once per frame
	void Update () {
		// if(Input.inputString.Equals("v"))
		// {
		// 	_ValidationManager.AddTravelers(TravelersDocuments);
		// 	_ValidationManager.validate();
		// 	OnValidationDone(_ValidationManager.numberOfCorrectlyProcessedTravelers, _ValidationManager.totalNumberOfTravelers);
		// }
	}
	private void performValidation()
	{
			_ValidationManager.AddTravelers(TravelersDocuments);
			_ValidationManager.validate();
			OnValidationDone(_ValidationManager.numberOfCorrectlyProcessedTravelers, _ValidationManager.totalNumberOfTravelers);
	}
	private void TakeTraveler(GameObject traveler)
	{
		CurrentTraveler = traveler;
	}

	private void setDecision(bool PlayerDecision)
	{
		if(CurrentTraveler != null)
		{
			if(CurrentTraveler.GetComponent<DocumentsManager>() != null)
			{
				CurrentTraveler.GetComponent<DocumentsManager>().HasPassed = PlayerDecision;
			}
			TravelersDocuments.Add(CurrentTraveler.GetComponent<DocumentsManager>().CopyDocs());
		    OnDecisionMade(PlayerDecision, CurrentTraveler);
			CurrentTraveler = null;
			DecisionSoundEvent (PlayerDecision);
		}
	}


}
