using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class IdValidityRule : Rule {

	public IdValidityRule(){
		Label = "Check that the travelers have an ID card and that it is valid";
	}

    public override bool validate(DocumentsFile docs)
    {
        IDCard idCard = (IDCard) docs.Docs.First(d => d.docType == DocumentType.ID);
        Passport passport = (Passport) docs.Docs.First(d => d.docType == DocumentType.Passport);

        return  idCard.DateOfBirth == passport.OwnerBirthday
            && idCard.OwnerName == passport.OwnerName
            && idCard.Gender == passport.RealGender
            && idCard.ValidUntil.Date >= DateTime.Now.Date;        
    }
}
