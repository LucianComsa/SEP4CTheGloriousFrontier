using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class PassportGenerator {

	public void generatePassport(Passport passport)
	{
		passport.OwnerGender = generateRandomGender (passport);
		passport.OwnerName = generateRandomName (passport.RealGender);
		passport.ExpirationDate = generateRandomExpDate ();
		passport.OwnerBirthday = generateRandomBirthday ();
		passport.SerialNumber = generateRandomSerialNo ();
		passport.OwnerCountry = generateRandomCountry ();

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
	private string generateRandomName(string gender)
	{
		int rand = Random.Range (1, 10); //10 possible names for each gender
		if (gender.Equals ("M")) {
			switch (rand) {
			case 1:
				return "Jeff Daniels";
			case 2:
				return "Bob Smith";
			case 3:
				return "George Brown";
			case 4:
				return "Michael Down";
			case 5:
				return "John Pump";
			case 6:
				return "Karl Pilkington";
			case 7:
				return "Ralph Stephenson";
			case 8:
				return "Ricky Thompson";
			case 9:
				return "Nick Anderson";
			case 10:
				return "Will Young";
			case 11: 
				return "Kasper Knop";
			case 12: 
				return "Jacob Knop";
			case 13: 
				return "Sebastian Basca";
			case 14: 
				return "Lucian Comsa";
			case 15: 
				return "Demian Ieremie";	
			case 16: 
				return "Nicolai Onov";
			case 17: 
				return "Octavian Grozman";
			case 18: 
				return "Vasile Popescu";
			case 19: 
				return "Jora Bartan";
			case 20: 
				return "Michael Jackson";
			case 21: 
				return "James Bond";
			}
			return "null";
		} 
		else {
			switch (rand) {
			case 1:
				return "Michelle Smith";
			case 2:
				return "Victoria Lipan";
			case 3:
				return "Jennifer Brown";
			case 4:
				return "Nancy Portmouth";
			case 5:
				return "Mary Johnson";
			case 6:
				return "Betty Jones";
			case 7:
				return "Margareth Williams";
			case 8:
				return "Maria Ramirez";
			case 9:
				return "Hellen Davis";
			case 10:
				return "Sarah Walker";
			}
			return "null";
		}
	}
	private DateTime generateRandomExpDate()
	{
		int rand = Random.Range (1,10);
		DateTime today = DateTime.Now;
		DateTime expiryDate;
		//10 % chance is expired
		if (rand == 2) {
			int randYear = today.Year - Random.Range (0, 2);
			int randMonth = Random.Range (1, 12);
			int randDay = Random.Range (1, 25);
			expiryDate = new DateTime (randYear,randMonth,randDay);
			return expiryDate;
		}
		else {
			int randYear = today.Year + Random.Range (0, 2);
			int randMonth = today.Month + Random.Range (-1, 2);
			if (randMonth < 1 || randMonth > 12) {
				randMonth = today.Month;
			}
			int randDay = Random.Range (1, 31);
			expiryDate = new DateTime(randYear,randMonth,randDay);
			return expiryDate;
		}

	}
	private DateTime generateRandomBirthday()
	{
		int randYear = Random.Range (1930, 1997);
		int randMonth = Random.Range (1, 12);
		int randDay = Random.Range (1, 31);
		DateTime birthday = new DateTime (randYear, randMonth, randDay);
		return birthday;
	}
	private string generateRandomSerialNo()
	{
		String randomSelection = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
		String serialNumber = "";
		for (int i = 0; i < 8; i++) {
			serialNumber += randomSelection[Random.Range(0,35)];
		}
		return serialNumber;

	}
	private string generateRandomCountry()
	{
		int rand = Random.Range (1, 27);
		switch (rand) {
		case 1: case 2: case 3: case 4: case 5:
			return "United Kingdom";
		case 6: case 7: case 8: case 9:
			return "United States";
		case 10: case 11: case 12:
			return "Romania";
		case 13: case 14: case 15: case 16:
			return "Denmark";
		case 17: case 18:
			return "Moldova";
		case 19: case 20:
			return "Hungary";
		case 21: case 22:
			return "Malta";
		case 23: case 24: 
			return "Sweden";
		case 25: case 26: case 27:
			return "Israel";
		}
		return "null";
	}

}
