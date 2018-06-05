using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ValidationManager {
    private LevelSettings levelSettings;
	public int numberOfCorrectlyProcessedTravelers = 0;
	public int totalNumberOfTravelers = 0;
	private DocumentsFile[] travelersToProcess; 
	[SerializeField]
	private int level; 
	
	//THE CONSTRUCTOR OF VALIDATION MANAGER IS RESPONSIBLE FOR GRABBING THE ARRAY OF RULES FROM THE RULEBOOK
	//FOR THE CORRESPONDING LEVEL
	public ValidationManager(int level) 
	{
		this.level = level;
		this.levelSettings = RuleBook.getLevelSettings(level);
	}
	public void AddTravelers(List<DocumentsFile> Travelers)
	{
		travelersToProcess = Travelers.ToArray();
	}
	public void validate()
    { 
		totalNumberOfTravelers = travelersToProcess.Count();
		validateDocumentsAvailability();
        foreach(DocumentsFile docs in travelersToProcess){
			if(checkDocumentsWithRules(docs) == docs.HasPassed)
				numberOfCorrectlyProcessedTravelers++;
		}
		Debug.Log("You have processed a total of: " + totalNumberOfTravelers +" travelers and have correctly decided on: " + numberOfCorrectlyProcessedTravelers + " travelers");
		//numberOfCorrectlyProcessedTravelers = 0;
    }

	private void validateDocumentsAvailability(){
		int i = 0;
		foreach (DocumentsFile docs in travelersToProcess){
			if(!checkDocumentsAvailabiltiy(docs)){
				if(docs.HasPassed == false)
					numberOfCorrectlyProcessedTravelers++;
				
				travelersToProcess = (DocumentsFile[])travelersToProcess.Except(new DocumentsFile[]{travelersToProcess[i]});
			}
			i++;	
		}
	} 

	private bool checkDocumentsWithRules(DocumentsFile docs){
		foreach ( IRule rule in levelSettings.Rules ) {
			if(!rule.validate(docs))
				return false;
		}
		return true;
	}

	private bool checkDocumentsAvailabiltiy(DocumentsFile docs){
		foreach (DocumentType docType in levelSettings.RequiredDocuments){
			if(!docs.Docs
			.Select(d => d.docType)
			.Contains(docType))
				return false;
		}
		return true;
	}


}
