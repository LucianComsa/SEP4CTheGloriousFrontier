using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Passport : Document{


	public string OwnerName;
	public string OwnerGender;
	public DateTime ExpirationDate;
	public DateTime OwnerBirthday;
	public string SerialNumber;
	public string OwnerCountry;

	public string RealGender;

	private PassportGenerator DocumentGeneratorScript;

	public Passport(string realGender)
		:base(DocumentType.Passport)
	{
		RealGender = realGender;

        DocumentGeneratorScript = new PassportGenerator();
		
		DocumentGeneratorScript.generatePassport (this);

	}
	public String GetDocInfo()
	{
		return "Passport: Name ("+OwnerName+") Gender ("+OwnerGender+") Exp Date ("+ExpirationDate.ToString()+") Birthday ("+OwnerBirthday+") SerialNo ("+SerialNumber+") Country ("+OwnerCountry+")";
	}

}
