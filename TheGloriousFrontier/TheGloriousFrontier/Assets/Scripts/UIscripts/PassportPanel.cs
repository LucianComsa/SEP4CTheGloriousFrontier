using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassportPanel : MonoBehaviour {

	public static Text OwnerName;
	public static Text SerialNo;
	public static Text FieldOfWork;
	public static Text ValidUntil;
	public static Text Gender;
	public static Text Country;
	public static Text DateOfBirth;

	void Start () {
		var passportPanelTransform = transform.Find("PassportPanel").transform;

		OwnerName = passportPanelTransform.Find("OwnerName").GetComponent<Text>();
		SerialNo = passportPanelTransform.Find("SerialNo").GetComponent<Text>();
		ValidUntil = passportPanelTransform.Find("ValidUntil").GetComponent<Text>();
		Gender = passportPanelTransform.Find("Gender").GetComponent<Text>();
		Country = passportPanelTransform.Find("Country").GetComponent<Text>();
		DateOfBirth = passportPanelTransform.Find("DateOfBirth").GetComponent<Text>();
	}
	
	public static void PopulateView(Passport passport){
		var format = "dd/MM/yyyy";

        OwnerName.text = passport.OwnerName;
        ValidUntil.text = passport.ExpirationDate.ToString(format);
        SerialNo.text = passport.SerialNumber;
        Gender.text = passport.OwnerGender;
        DateOfBirth.text = passport.OwnerBirthday.Date.ToString(format);
        Country.text = passport.OwnerCountry;
    
	}

}
