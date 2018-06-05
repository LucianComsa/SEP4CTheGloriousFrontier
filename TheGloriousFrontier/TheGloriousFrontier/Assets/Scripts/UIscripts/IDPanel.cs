using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IDPanel : MonoBehaviour {

	public static Text OwnerName;
	public static Text ValidUntil;
	public static Text Gender;
	public static Text DateOfBirth;

	void Start () {
		var idPanelTransform = transform.Find("IDPanel").transform;

		OwnerName = idPanelTransform.Find("OwnerName").GetComponent<Text>();
		ValidUntil = idPanelTransform.Find("ValidUntil").GetComponent<Text>();
		Gender = idPanelTransform.Find("Gender").GetComponent<Text>();
		DateOfBirth = idPanelTransform.Find("DateOfBirth").GetComponent<Text>();
	}

	public static void PopulateView(IDCard idCard)
    {
		var format = "dd/MM/yyyy";

        OwnerName.text = idCard.OwnerName;
        ValidUntil.text = idCard.ValidUntil.ToString(format);
        Gender.text = idCard.Gender;
        DateOfBirth.text = idCard.DateOfBirth.ToString(format);
    }
	
}
