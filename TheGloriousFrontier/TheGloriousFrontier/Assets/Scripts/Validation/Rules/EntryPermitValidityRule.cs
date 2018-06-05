using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPermitValidityRule : Rule
{
	public EntryPermitValidityRule(){
		Label = "Check that the traveler has an entry permit and that it is valid";
	}

    public override bool validate(DocumentsFile docs)
    {
        EntryPermit entryPermit = null;
        Passport passport = null;

        foreach(Document document in docs.Docs) {
            if (document.docType == DocumentType.EntryPermit) {
                entryPermit = (EntryPermit)document;
            }
            if (document.docType == DocumentType.Passport) {
                passport = (Passport)document;
            }
        }
        //TimeSpan ts = new TimeSpan(00,00,00);
        //entryPermit.EnterBy = entryPermit.EnterBy.Date + ts;
        if (entryPermit == null ||
            passport == null ||
            entryPermit.EnterBy.Date < DateTime.Now.Date ||
            entryPermit.OwnerName != passport.OwnerName ||
            entryPermit.PassportSerial != passport.SerialNumber) return false;

        return true;
    }
}
