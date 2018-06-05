using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class DocumentsCreation : MonoBehaviour {

	private DocumentsManager manager;
	// Use this for initialization
	void Start () {
		if (gameObject.GetComponent<DocumentsManager> () != null) 
		{
			manager = gameObject.GetComponent<DocumentsManager> ();
		}
		//should be edited to take the level info from the static gameInfo class
		LevelSettings settings = RuleBook.getLevelSettings (CurrentGameInfo.CurrentLevel);
		generateDocs (settings.RequiredDocuments);

	}
	private void generateDocs(DocumentType[] required)
	{
		List<Document> travelersDocuments = new List<Document> ();
		int rand = Random.Range (1,100);
		if (rand == 50) {
			manager.Docs = travelersDocuments.ToArray ();
			return;
		} 
		else {
			TravelerRealInfo info;
			info = gameObject.GetComponent<TravelerRealInfo> ();
			Passport pass = new Passport (info.gender);
			foreach (DocumentType doc in required) {
				if (doc == DocumentType.Passport) {
					travelersDocuments.Add (pass);
					string DebugInfo = pass.GetDocInfo ();
					Debug.Log (DebugInfo);
				} else if (doc == DocumentType.EntryPermit) {
					EntryPermit entryPermit = new EntryPermit (pass);
					travelersDocuments.Add (entryPermit);
					string DebugInfo = entryPermit.GetDocInfo ();
					Debug.Log (DebugInfo);
				} else if (doc == DocumentType.ID) {
					IDCard id = new IDCard (pass);
					travelersDocuments.Add (id);
					string DebugInfo = id.GetDocInfo ();
					Debug.Log (DebugInfo);
				} else if (doc == DocumentType.MedicalCard) {
					MedicalCard medCard = new MedicalCard (pass);
					travelersDocuments.Add (medCard);
					string DebugInfo = medCard.GetDocInfo ();
					Debug.Log (DebugInfo);
				} else if (doc == DocumentType.WorkPermit) {
					WorkPermit workPermit = new WorkPermit (pass);
					travelersDocuments.Add (workPermit);
					string DebugInfo = workPermit.GetDocInfo ();
					Debug.Log (DebugInfo);
				}
			}
		}
		manager.Docs = travelersDocuments.ToArray();

	}


}
