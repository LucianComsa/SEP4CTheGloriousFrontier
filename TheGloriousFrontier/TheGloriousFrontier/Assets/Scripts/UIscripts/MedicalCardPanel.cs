using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MedicalCardPanel : MonoBehaviour {

	public static Text OwnerName;
	public static Text ValidUntil;


	void Start () {
		var medicalCardPanelTransform = transform.Find("MedicalCardPanel").transform;

		OwnerName = medicalCardPanelTransform.Find("OwnerName").GetComponent<Text>();
		ValidUntil = medicalCardPanelTransform.Find("ValidUntil").GetComponent<Text>();
	
	}

	public static void PopulateView(MedicalCard MedicalCard)
    {
		var format = "dd/MM/yyyy";

        OwnerName.text = MedicalCard.OwnerName;
        ValidUntil.text = MedicalCard.ValidUntil.ToString(format);
		
    }
}
