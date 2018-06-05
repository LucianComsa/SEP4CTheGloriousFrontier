using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicalCardValidityRule : Rule
{
    public MedicalCardValidityRule()
    {
		Label = "Check that the travelers have a medical card and that it is valid";
    }

    public override bool validate(DocumentsFile docs)
    {
		 Passport passport = null;
         MedicalCard card = null;
         foreach(Document d in docs.Docs)
         {
             if(d.docType.Equals(DocumentType.MedicalCard)) card = (MedicalCard)d;
             if(d.docType.Equals(DocumentType.Passport)) passport = (Passport)d;
         }
        // if(passport == null && card == null) return false;

         if(passport.OwnerName.ToLower().Equals(card.OwnerName.ToLower())
         && card.ValidUntil.Date >= DateTime.Now.Date
         ) return true;
         else return false;
    }
}
