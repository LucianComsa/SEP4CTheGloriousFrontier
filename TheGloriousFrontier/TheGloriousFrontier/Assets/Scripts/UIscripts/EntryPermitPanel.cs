using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntryPermitPanel : MonoBehaviour {

	public static Text OwnerName;
	public static Text SerialNo;
	public static Text Duration;
	public static Text EnterBy;
	public static Text Purpose;
	

	void Start () {
		var entryPermitTransform = transform.Find("EntryPermitPanel").transform;

		OwnerName = entryPermitTransform.Find("OwnerName").GetComponent<Text>();
		SerialNo = entryPermitTransform.Find("SerialNo").GetComponent<Text>();
		Duration = entryPermitTransform.Find("Duration").GetComponent<Text>();
		EnterBy = entryPermitTransform.Find("EnterBy").GetComponent<Text>();
		Purpose = entryPermitTransform.Find("Purpose").GetComponent<Text>();
	}

	public static void PopulateView(EntryPermit entryPermit)
    {
        var format = "dd/MM/yyyy";

        OwnerName.text = entryPermit.OwnerName;
        Purpose.text = entryPermit.Purpose;
        SerialNo.text = entryPermit.PassportSerial;
        Duration.text = entryPermit.Duration;
        EnterBy.text = entryPermit.EnterBy.ToString(format);
    }
}
