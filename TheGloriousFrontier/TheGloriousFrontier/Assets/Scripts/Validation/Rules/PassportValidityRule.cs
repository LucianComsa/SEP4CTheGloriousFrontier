using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassportValidityRule : Rule {

    public PassportValidityRule()
    {
		Label = "Check that the travelers have a passport and that it is valid";
    }

    public override bool validate(DocumentsFile docs)
    {
		Passport passport = null;
        foreach(Document d in docs.Docs)
		{
			if(d.docType.Equals(DocumentType.Passport))
			{
				passport =(Passport) d;
				break;
			}
		}
	//	if(passport == null) return false;
		
		if(passport.ExpirationDate.Date >= DateTime.Now.Date
		&& passport.RealGender.ToUpper().Equals(passport.OwnerGender.ToUpper())
		) return true;
		else return false;
    } 
}
