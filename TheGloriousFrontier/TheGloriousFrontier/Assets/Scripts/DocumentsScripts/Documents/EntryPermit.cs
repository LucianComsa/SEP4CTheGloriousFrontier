using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EntryPermit : Document{

	public string OwnerName;
	public Passport OwnerPassport;
	public string PassportSerial;
	public string Purpose;
	public string Duration;
	public DateTime EnterBy;

	private EntryPermitGenerator DocumentGeneratorScript;

	public EntryPermit(Passport ownersPassport)
	:base(DocumentType.EntryPermit)
	{
		OwnerPassport = ownersPassport;
	    DocumentGeneratorScript = new EntryPermitGenerator();
        DocumentGeneratorScript.generateEntryPermit (this, OwnerPassport);
	}
	public String GetDocInfo()
	{
		return "EP: Name ("+OwnerName+") Purpose ("+Purpose+") Duration ("+Duration+") Enter by ("+EnterBy.ToString()+")";
	}

    
}
