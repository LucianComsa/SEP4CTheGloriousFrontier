using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkPermitPanel : MonoBehaviour {

	public static Text OwnerName;
	public static Text SerialNo;
	public static Text FieldOfWork;
	public static Text ValidUntil;

	// Use this for initialization
	void Start () {
		var workPermitPanelTransform = transform.Find("WorkPermitPanel").transform;

		OwnerName = workPermitPanelTransform.Find("OwnerName").GetComponent<Text>();
		SerialNo = workPermitPanelTransform.Find("SerialNo").GetComponent<Text>();
		FieldOfWork = workPermitPanelTransform.Find("FieldOfWork").GetComponent<Text>();
		ValidUntil = workPermitPanelTransform.Find("ValidUntil").GetComponent<Text>();
	}
	
	public static void PopulateView(WorkPermit WorkPermit)
    {
		var format = "dd/MM/yyyy";
		
        OwnerName.text = WorkPermit.OwnerName;
        FieldOfWork.text = WorkPermit.FieldOfWork;
        ValidUntil.text = WorkPermit.ValidUntil.Date.ToString(format);
        SerialNo.text = WorkPermit.PassportSerial;
    }
	
}
