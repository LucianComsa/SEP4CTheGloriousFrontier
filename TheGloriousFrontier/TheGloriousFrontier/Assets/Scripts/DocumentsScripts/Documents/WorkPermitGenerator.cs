using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class WorkPermitGenerator {

	public void generateWorkPermit(WorkPermit permit, Passport ownersPassport)
	{
		permit.ValidUntil = generateValidUntilDate ();
		permit.OwnerName = generateRandomOwnerName (ownersPassport.OwnerName);
		permit.FieldOfWork = generateRandomFieldOfWork ();
		permit.PassportSerial = generateRandomSerial (ownersPassport.SerialNumber);
	}
	private DateTime generateValidUntilDate()
	{
		DateTime now = DateTime.Now;
		int rand = Random.Range (1, 10);
		//10% chance is expired date
		if (rand == 6) {
			now.AddMonths (-1);
			return now;
		}
		else {
			now.AddMonths (Random.Range (1, 4));
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
	private string generateRandomFieldOfWork()
	{
		int rand = Random.Range (1, 4);
		switch (rand) {
		case 1:
			return "Agriculture";
		case 2:
			return "Medical";
		case 3:
			return "Transport";
		case 4:
			return "Cleaning";
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
