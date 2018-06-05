using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject entryPermitPrefab;
	[SerializeField]
	private GameObject passportPrefab;
	[SerializeField]
	private GameObject workPermitPrefab;
	[SerializeField]
	private GameObject medicalCardPrefab;
	[SerializeField]
	private GameObject idCardPrefab;
	[SerializeField]
	private TravelerArrivalInterraction TravelerArrival;

	private List<GameObject> spawnedDocuments;
	
	[HideInInspector]
	public bool hasSpawned;

	// Use this for initialization
	void Start () {
		hasSpawned = false;
        spawnedDocuments = new List<GameObject>();
		TravelerArrival.OnTravelerCaptured += SpawnDocumentOnTable;
	    TravelerArrival.OnTravelerLeft += DespawnDocuments;

	}
	private List<DocumentType> convertToType(Document[] docs)
	{
		List<DocumentType> types = new List<DocumentType>();
		for(int i = 0; i < docs.Length; i++)
		{
			types.Add(docs[i].docType);
		}
		return types;
	}
	public void SpawnDocumentOnTable(GameObject traveler)
	{
	    if (hasSpawned) return;
		if(traveler.GetComponent<DocumentsManager>().Docs == null) return;

		List<DocumentType> types = convertToType(traveler.GetComponent<DocumentsManager>().Docs);
		for (int i = 0; i < types.Count; i++) 
		{
			if (types[i] == DocumentType.EntryPermit) {
				Vector3 position = new Vector3 (70.59721f, -31.4f, -52.59643f);
				Quaternion rotation = new Quaternion (0, -74.76501f, 0, 0);
				GameObject item = Instantiate (entryPermitPrefab, position, rotation);
			    spawnedDocuments.Add(item);
            } else if (types[i] == DocumentType.Passport) {
				Vector3 position = new Vector3 (67.91711f, -31.43f, -52.15291f);
				//Quaternion rotation = new Quaternion (0, -90.992f, 0, 0);
				Quaternion rotation = new Quaternion (0, 0, 0, 0);
			    GameObject item = Instantiate (passportPrefab, position, rotation);
			    spawnedDocuments.Add(item);
            } else if (types[i] == DocumentType.WorkPermit) {
				Vector3 position = new Vector3 (66.41f, -31.43f, -52.46f);
				Quaternion rotation = new Quaternion (0, -55.279f, 0, 0);
			    GameObject item = Instantiate (workPermitPrefab, position, rotation);
			    spawnedDocuments.Add(item);
            } else if (types[i] == DocumentType.MedicalCard) {
				Vector3 position = new Vector3 (68.85f, -31.46f, -52.66f);
				Quaternion rotation = new Quaternion (0, 0, 0, 0);
			    GameObject item = Instantiate (medicalCardPrefab, position, rotation);
			    spawnedDocuments.Add(item);
            } else if (types[i] == DocumentType.ID) {
				Vector3 position = new Vector3 (69.31167f, -31.44f, -51.86676f);
				Quaternion rotation = new Quaternion (0, -42.274f, 0, 0);
			    GameObject item = Instantiate (idCardPrefab, position, rotation);
			    spawnedDocuments.Add(item);
            }
		}
		hasSpawned = true;
	}
	public void DespawnDocuments()
	{
		for (int i = 0; i < spawnedDocuments.Count; i++) {
			Destroy (spawnedDocuments [i]);
		}
		Debug.Log (spawnedDocuments.Count);
		spawnedDocuments = new List<GameObject>();
		hasSpawned = false;
	}

}
