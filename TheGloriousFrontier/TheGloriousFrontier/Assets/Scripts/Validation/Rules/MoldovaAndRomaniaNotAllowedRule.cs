using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoldovaAndRomaniaNotAllowedRule : Rule
{
	public MoldovaAndRomaniaNotAllowedRule(){
		Label = "Travellers from Moldova and Romania are not allowed to pass the border";
	}

    public override bool validate(DocumentsFile docs)
    {
        Passport passport = null;

        foreach(Document document in docs.Docs) {
            if (document.docType == DocumentType.Passport) {
                passport = (Passport)document;
                break;
            }
        }

        string[] countriesNotAllowed = new string[] {"Moldova", "Romania"};

        if (passport == null ||
            countriesNotAllowed.Contains(passport.OwnerCountry)) return false;

        return true;
    }
}
