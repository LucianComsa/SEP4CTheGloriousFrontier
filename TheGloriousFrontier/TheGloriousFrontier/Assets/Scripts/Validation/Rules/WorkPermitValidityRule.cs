using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class WorkPermitValidityRule : Rule
{
	public WorkPermitValidityRule(){
		Label = "Check that the travelers have a work permit and that it is valid";
	}

    public override bool validate(DocumentsFile docs)
    {
        WorkPermit workPermit = (WorkPermit) docs.Docs.First(d => d.docType == DocumentType.WorkPermit);
        Passport passport = (Passport) docs.Docs.First(d => d.docType == DocumentType.Passport);

        return workPermit.PassportSerial == passport.SerialNumber
            && workPermit.OwnerName == passport.OwnerName
            && workPermit.ValidUntil.Date >= DateTime.Now.Date;        
    }
}
