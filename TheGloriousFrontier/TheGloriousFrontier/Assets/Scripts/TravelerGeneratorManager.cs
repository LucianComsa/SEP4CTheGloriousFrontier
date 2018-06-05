using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TravelerGeneratorManager : MonoBehaviour
{
	public const int TRAVELLER_LAYER = 8; 
	private TravelerGenerator prefabGenerator;

	[SerializeField]
	private Canvas UICanvas;

	[SerializeField]
	private GameObject RuleListTextBox;
	private bool isGeneratingTravellers;

	private GameObject current = null;

	[SerializeField]
	private Vector3 InitialPosition;

    private bool isFirst = true;
	public event Action<GameObject> OnTravelerInstantiated = delegate {};
	
	[SerializeField]
	private FinishPositionHandler accept, reject;
	[SerializeField]
	private bool shouldResizeCharacter = false;

	void Start ()
	{
		if(gameObject.GetComponent<TravelerGenerator>() != null)
		{
			prefabGenerator = gameObject.GetComponent<TravelerGenerator>();
		}	
		accept.OnTravelerFinished += getNextGenerated;
		reject.OnTravelerFinished += getNextGenerated;

		Timer Timer = UICanvas.GetComponent<Timer>();
		if (Timer != null) {
			// if timer ends (which means that level is finished), it stops to generate prefabs
			// when next level starts, it starts to generate again
			Timer.OnLevelFinished += ToggleGeneratingTravellers;
			//LevelFinishedController.OnStartNextLevel += ToggleGeneratingTravellers;
		}

		RuleListFiller RuleListFiller = RuleListTextBox.GetComponent<RuleListFiller>();
		if (RuleListFiller != null) {
			// starts to generate travellers (prefabs)
			RuleListFiller.OnRulesPanelClosed += ToggleGeneratingTravellers;
		}

		//InitialPosition = new Vector3(-70, 1, 20);

	}

	void ToggleGeneratingTravellers() 
	{
		isGeneratingTravellers = !isGeneratingTravellers;
		getNextGenerated();
	}
	
	void Update () 
	{
		if(isFirst)
		{
			getNextGenerated();
		    isFirst = !isFirst; 
		}
	}

	public void getNextGenerated()
	{
		DestroyCurrent();
		if (!isGeneratingTravellers) return;
		GameObject traveller = prefabGenerator.getRandomPrefab();
		traveller.layer = TRAVELLER_LAYER;
		current = Instantiate(traveller, InitialPosition, Quaternion.identity);
		if(shouldResizeCharacter) current.transform.localScale = new Vector3(1F,1F,1F);
		//set destination
		OnTravelerInstantiated(current);
	}
	private void DestroyCurrent()
	{
		if(current != null)
		{
			Destroy(current);
		}
	}
	
}
