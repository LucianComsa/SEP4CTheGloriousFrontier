using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class IDCardGenerator {

	public void generateIDCard(IDCard card, Passport ownersPassport)
	{
		card.ValidUntil = generateValidUntilDate ();
		card.OwnerName = generateRandomOwnerName (ownersPassport.OwnerName);
		card.Gender = generateRandomGender (ownersPassport);
		card.DateOfBirth = ownersPassport.OwnerBirthday;
	}
	private DateTime generateValidUntilDate()
	{
		DateTime now = DateTime.Now;
		int rand = Random.Range (1, 10);
		//10% chance is expired date
		if (rand == 6) {
			now.AddMonths (-1);
			now.AddDays (-7);
			return now;
		}
		else {
			now.AddMonths (Random.Range (1, 6));
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
	private string generateRandomGender(Passport passport)
	{
		int rand = Random.Range (1,10);
		//gives a 10% chance that the gender might be wrong
		if (rand == 5) {
			if (passport.RealGender.Equals ("M")) {
				return "F";
			} else
				return "M";
		} else
			return passport.RealGender;
	}
}
