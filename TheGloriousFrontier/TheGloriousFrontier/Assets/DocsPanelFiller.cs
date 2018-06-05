using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DocsPanelFiller : MonoBehaviour {

	[SerializeField]
	private TravelerArrivalInterraction travelerArrival;
	[SerializeField]
	private PlayerDecisionManager DecisionManager;

	private GameObject passportBtn;
	private GameObject workPermitBtn;
	private GameObject idBtn;
	private GameObject entryPermitBtn;
	private GameObject medicalCardBtn;

	public event Action OnDocsOpened = delegate {};
	  
	void Start () {
		transform.localScale = new Vector3(0,0,0);

		var parentTransform = transform.Find("DocShortcutsPanel").transform;
		passportBtn = parentTransform.Find("PassportBtn").gameObject;
		workPermitBtn = parentTransform.Find("WorkPermitBtn").gameObject;
		entryPermitBtn = parentTransform.Find("EntryPermitBtn").gameObject;		
		medicalCardBtn = parentTransform.Find("MedicalCardBtn").gameObject;
		idBtn = parentTransform.Find("IDBtn").gameObject;
		
		travelerArrival.OnTravelerCaptured += ConfigureDocButtons;		
		DecisionManager.OnDecisionMade += DeactivateAllDocButtons;
	}
	
	private void ConfigureDocButtons(GameObject traveler){
		var docs = traveler.GetComponent<DocumentsManager>().Docs;		
		foreach(Document doc in docs){
			switch(doc.docType){
				case DocumentType.Passport: 
					passportBtn.SetActive(true);
					PassportPanel.PopulateView((Passport) doc);
					break;
				case DocumentType.WorkPermit:
					workPermitBtn.SetActive(true);
					WorkPermitPanel.PopulateView((WorkPermit) doc);
					break;
				case DocumentType.EntryPermit: 
					entryPermitBtn.SetActive(true);
					EntryPermitPanel.PopulateView((EntryPermit) doc);
					break;
				case DocumentType.MedicalCard:
					medicalCardBtn.SetActive(true);
					MedicalCardPanel.PopulateView((MedicalCard) doc);
					break;
				case DocumentType.ID: 
					idBtn.SetActive(true);
					IDPanel.PopulateView((IDCard) doc);
					break;
			}
		}
	}

	private void DeactivateAllDocButtons(bool decision, GameObject gameObject){
		passportBtn.SetActive(false);
		workPermitBtn.SetActive(false);
		entryPermitBtn.SetActive(false);
		medicalCardBtn.SetActive(false);
		idBtn.gameObject.SetActive(false);
	}

	public void ToggleVisibility(bool isVisible){
		if(isVisible) {
			transform.localScale = new Vector3(1,1,1);
			OnDocsOpened();
		}
		else
			transform.localScale = new Vector3(0,0,0);
	}
}
