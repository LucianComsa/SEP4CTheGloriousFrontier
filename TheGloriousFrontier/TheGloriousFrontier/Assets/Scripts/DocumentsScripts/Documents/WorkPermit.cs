using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WorkPermit : Document {

	public string OwnerName;
	public Passport OwnerPassport;
	public string PassportSerial;
	public string FieldOfWork;
	public DateTime ValidUntil;

	private WorkPermitGenerator DocumentGeneratorScript;

	public WorkPermit(Passport ownersPassport)
		:base(DocumentType.WorkPermit)
	{
		OwnerPassport = ownersPassport;
	    DocumentGeneratorScript = new WorkPermitGenerator();
        DocumentGeneratorScript.generateWorkPermit (this, OwnerPassport);
		Debug.Log("Work Permit created!");
		
	}
	public String GetDocInfo()
	{
		return "WP: Name ("+OwnerName+") Field of work ("+FieldOfWork+") Valid Until ("+ValidUntil.ToString()+")";
	}

    
}
