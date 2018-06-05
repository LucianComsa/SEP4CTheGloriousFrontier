using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IDCard : Document {

	public string OwnerName;
	public Passport OwnersPassport;
	public DateTime ValidUntil;
	public DateTime DateOfBirth;
	public string Gender;

	private IDCardGenerator DocumentGeneratorScript;

	public IDCard( Passport ownersPassport)
		:base(DocumentType.ID)
	{
		OwnersPassport = ownersPassport;
	    DocumentGeneratorScript = new IDCardGenerator();
        DocumentGeneratorScript.generateIDCard (this, ownersPassport);


	}
	public String GetDocInfo()
	{
		return "ID: Name ("+OwnerName+") Valid Until ("+ValidUntil.ToString()+") Birthday ("+DateOfBirth.ToString()+") Gender ("+Gender+")";
	}

	
}
