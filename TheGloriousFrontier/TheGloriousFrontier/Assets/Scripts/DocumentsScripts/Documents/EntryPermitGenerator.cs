using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class EntryPermitGenerator {

	public void generateEntryPermit(EntryPermit permit, Passport passport)
	{
		permit.Duration = generateRandomEntryDuration ();
		permit.EnterBy = generateRandomEntryByDate ();
		permit.OwnerName = generateRandomOwnerName (passport.OwnerName);
		permit.Purpose = generateRandomPurpose ();
		if (permit.Purpose.Equals ("Immigration"))
			permit.Duration = "Forever";
		permit.PassportSerial = generateRandomSerial (passport.SerialNumber);
	}
	private string generateRandomEntryDuration()
	{
		int rand = Random.Range (1, 6);
		switch (rand) {
		case 1:
			return "2 Days";
		case 2:
			return "14 Days";
		case 3:
			return "1 Month";
		case 4:
			return "2 Months";
		case 5:
			return "3 Months";
		case 6:
			return "1 Year";
		}
		return "2 Days";
	}
	private DateTime generateRandomEntryByDate()
	{
		DateTime now = DateTime.Now;
		int rand = Random.Range (1, 10);
		//10% chance is expired date
		if (rand == 6) {
			now.AddDays (-2);
			return now;
		}
		else {
			now.AddDays (Random.Range (2, 10));
			return now;
		}
	}
	private string generateRandomOwnerName(string realName)
	{
		int rand = Random.Range (1, 10);
		//10% chance the name is wrong
		if (rand == 2) {
			int rand2 = Random.Range (1, 10);
			switch (rand2) {
			case 1:
				return "Michael Kostava";
			case 2:
				return "George Hagi";
			case 3:
				return "Michelle Obama";
			case 4:
				return "Vladimir Brown";
			case 5:
				return "Jon Abe";
			case 6:
				return "Mathilda Smith";
			case 7:
				return "Will Jones";
			case 8:
				return "Carmen Stone";
			case 9:
				return "Lucy Wright";
			case 10:
				return "John Scott";
			}
		} 
		else {
			return realName;
		}
		return "null";
	}
	private string generateRandomPurpose()
	{
		int rand = Random.Range (1, 4);
		switch (rand) {
		case 1:
			return "Work";
		case 2:
			return "Immigration";
		case 3:
			return "Transit";
		case 4:
			return "Visiting";
		}
		return "null";
	}
	private string generateRandomSerial(string realSerialNo)
	{
		int rand = Random.Range (1, 10);
		if (rand == 5) {
			String randomSelection = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
			String serialNumberFake = "";
			for (int i = 0; i < 8; i++) {
				serialNumberFake += randomSelection [Random.Range (0, 35)];
			}
			return serialNumberFake;
		} else {
			return realSerialNo;
		}
	}

}
