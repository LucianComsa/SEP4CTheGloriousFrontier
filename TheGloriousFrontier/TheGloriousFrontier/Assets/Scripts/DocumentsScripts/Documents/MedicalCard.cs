using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MedicalCard : Document{

	public string OwnerName;
	public Passport OwnersPassport;
	public DateTime ValidUntil;

	private MedicalCardGenerator DocumentGeneratorScript;

	public MedicalCard(Passport ownersPassport)
		:base(DocumentType.MedicalCard)
	{
		OwnersPassport = ownersPassport;
	    DocumentGeneratorScript = new MedicalCardGenerator();
        DocumentGeneratorScript.generateMedicalCard (this, ownersPassport);


	}
	public String GetDocInfo()
	{
		return "MEDCard: Name ("+OwnerName+") Valid Until ("+ValidUntil.ToString()+")";
	}

	
}
