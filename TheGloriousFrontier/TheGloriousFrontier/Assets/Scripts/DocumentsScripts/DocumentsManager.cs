using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentsManager : MonoBehaviour{

	public bool HasPassed {set; get;}
	[SerializeField]
	public Document[] Docs{get; set;}
    public DocumentsFile docs { get; set; }
	public DocumentsFile CopyDocs()
	{
		DocumentsFile dm = new DocumentsFile();
		dm.Docs = Docs;
		dm.HasPassed = HasPassed;
		return dm;
	}


	
}
