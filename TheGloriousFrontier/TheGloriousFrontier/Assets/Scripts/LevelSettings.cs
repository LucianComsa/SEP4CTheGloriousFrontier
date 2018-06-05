using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSettings  {

	public Rule[] Rules{get; set;} 
	public DocumentType[] RequiredDocuments{get; set;}

	public LevelSettings(Rule[] rules, DocumentType[] requiredDocuments){
		this.Rules = rules;
		this.RequiredDocuments = requiredDocuments;
	} 

}
