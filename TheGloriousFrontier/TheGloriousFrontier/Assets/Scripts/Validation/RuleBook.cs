using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//HERE ALL RULES FOR THE GAME WILL BE STORED AND MAPPED FOR EACH LEVEL OF THE GAME
public static class RuleBook
{
	private static Dictionary<int, LevelSettings> _levelSettings;
	static RuleBook(){
		_levelSettings = new Dictionary<int, LevelSettings>();

		//RULES FOR LEVEL -1- 
		_levelSettings.Add(1, new LevelSettings(
			new Rule[]{
				new PassportValidityRule(),
				new MoldovaAndRomaniaNotAllowedRule()
			},
			new DocumentType[]{
				DocumentType.Passport,
			}
			)
		);
		//RULES FOR LEVEL -2- 
		_levelSettings.Add(2, new LevelSettings(
			new Rule[]{
				new PassportValidityRule(),
				new EntryPermitValidityRule()
			},
			new DocumentType[]{
				DocumentType.Passport,
				DocumentType.EntryPermit,
			}
			)
		);
		//RULES FOR LEVEL -3- 
		_levelSettings.Add(3, new LevelSettings(
			new Rule[]{
				new PassportValidityRule(),
				new MedicalCardValidityRule()
			},
			new DocumentType[]{
				DocumentType.Passport,
				DocumentType.MedicalCard
			}
			)
		);
		//RULES FOR LEVEL -4- 
		_levelSettings.Add(4, new LevelSettings(
			new Rule[]{
				new PassportValidityRule(),
				new WorkPermitValidityRule()

			},
			new DocumentType[]{
				DocumentType.Passport,
				DocumentType.WorkPermit
			}
			)
		);
		//RULES FOR LEVEL -5- 
		_levelSettings.Add(5, new LevelSettings(
			new Rule[]{
				new PassportValidityRule(),
				new EntryPermitValidityRule(),
				new WorkPermitValidityRule()
			},
			new DocumentType[]{
				DocumentType.Passport,
				DocumentType.EntryPermit,
				DocumentType.WorkPermit
			}
			)
		);
		//RULES FOR LEVEL -6- 
		_levelSettings.Add(6, new LevelSettings(
			new Rule[]{
				new PassportValidityRule(),
				new IdValidityRule()
			},
			new DocumentType[]{
				DocumentType.Passport,
				DocumentType.ID
			}
			)
		);
		//RULES FOR LEVEL -7- 
		_levelSettings.Add(7, new LevelSettings(
			new Rule[]{
				new PassportValidityRule(),
				new IdValidityRule(),
				new MedicalCardValidityRule()
			},
			new DocumentType[]{
				DocumentType.Passport,
				DocumentType.ID,
				DocumentType.MedicalCard
			}
			)
		);
		//RULES FOR LEVEL -8- 
		_levelSettings.Add(8, new LevelSettings(
			new Rule[]{
				new PassportValidityRule(),
				new IdValidityRule(),
				new WorkPermitValidityRule()

			},
			new DocumentType[]{
				DocumentType.Passport,
				DocumentType.ID,
				DocumentType.WorkPermit
			}
			)
		);
		//RULES FOR LEVEL -9- 
		_levelSettings.Add(9, new LevelSettings(
			new Rule[]{
				new PassportValidityRule(),
				new EntryPermitValidityRule(),
				new MedicalCardValidityRule(),
				new IdValidityRule()

			},
			new DocumentType[]{
				DocumentType.Passport,
				DocumentType.EntryPermit,
				DocumentType.MedicalCard,
				DocumentType.ID
			}
			)
		);
		//RULES FOR LEVEL -10- 
		_levelSettings.Add(10, new LevelSettings(
			new Rule[]{
				new PassportValidityRule(),
				new EntryPermitValidityRule(),
				new MedicalCardValidityRule(),
				new WorkPermitValidityRule()
			},
			new DocumentType[]{
				DocumentType.Passport,
				DocumentType.EntryPermit,
				DocumentType.MedicalCard,
				DocumentType.WorkPermit
			}
			)
		);
		//RULES FOR LEVEL -11- 
		_levelSettings.Add(11, new LevelSettings(
			new Rule[]{
				new PassportValidityRule(),
				new IdValidityRule(),
				new MedicalCardValidityRule(),
				new WorkPermitValidityRule()
			},
			new DocumentType[]{
				DocumentType.Passport,
				DocumentType.ID,
				DocumentType.MedicalCard,
				DocumentType.WorkPermit
			}
			)
		);
		//RULES FOR LEVEL -12- 
		_levelSettings.Add(12, new LevelSettings(
			new Rule[]{
				new PassportValidityRule(),
				new IdValidityRule(),
				new EntryPermitValidityRule(),
				new WorkPermitValidityRule()
			},
			new DocumentType[]{
				DocumentType.Passport,
				DocumentType.ID,
				DocumentType.EntryPermit,
				DocumentType.WorkPermit
			}
			)
		);
		//RULES FOR LEVEL -13- 
		_levelSettings.Add(13, new LevelSettings(
			new Rule[]{
				new PassportValidityRule(),
				new IdValidityRule(),
				new EntryPermitValidityRule(),
				new WorkPermitValidityRule(),
				new MedicalCardValidityRule()
			},
			new DocumentType[]{
				DocumentType.Passport,
				DocumentType.ID,
				DocumentType.EntryPermit,
				DocumentType.WorkPermit,
				DocumentType.MedicalCard
			}
			)
		);
		//RULES FOR LEVEL -14- 
		_levelSettings.Add(14, new LevelSettings(
			new Rule[]{
				new PassportValidityRule(),
				new EntryPermitValidityRule(),
				new MedicalCardValidityRule(),
				new MoldovaAndRomaniaNotAllowedRule()
			},
			new DocumentType[]{
				DocumentType.Passport,
				DocumentType.EntryPermit,
				DocumentType.MedicalCard
			}
			)
		);
		//RULES FOR LEVEL -15- 
		_levelSettings.Add(15, new LevelSettings(
			new Rule[]{
				new PassportValidityRule(),
				new WorkPermitValidityRule(),
				new IdValidityRule(),
			},
			new DocumentType[]{
				DocumentType.Passport,
				DocumentType.WorkPermit,
				DocumentType.ID
			}
			)
		);
		//RULES FOR LEVEL -16- 
		_levelSettings.Add(16, new LevelSettings(
			new Rule[]{
				new PassportValidityRule(),
				new IdValidityRule()
			},
			new DocumentType[]{
				DocumentType.Passport,
				DocumentType.ID
			}
			)
		);
		//RULES FOR LEVEL -17- 
		_levelSettings.Add(17, new LevelSettings(
			new Rule[]{
				new PassportValidityRule(),
				new WorkPermitValidityRule(),
				new MedicalCardValidityRule()
			},
			new DocumentType[]{
				DocumentType.Passport,
				DocumentType.WorkPermit,
				DocumentType.MedicalCard
			}
			)
		);
		//RULES FOR LEVEL -18- 
		_levelSettings.Add(18, new LevelSettings(
			new Rule[]{
				new PassportValidityRule(),
				new EntryPermitValidityRule(),
				new MedicalCardValidityRule(),
				new WorkPermitValidityRule()
			},
			new DocumentType[]{
				DocumentType.Passport,
				DocumentType.EntryPermit,
				DocumentType.MedicalCard,
				DocumentType.WorkPermit
			}
			)
		);
		//RULES FOR LEVEL -19- 
		_levelSettings.Add(19, new LevelSettings(
			new Rule[]{
				new PassportValidityRule(),
				new IdValidityRule(),
				new MedicalCardValidityRule(),
				new WorkPermitValidityRule(),
				new EntryPermitValidityRule()
			},
			new DocumentType[]{
				DocumentType.Passport,
				DocumentType.ID,
				DocumentType.MedicalCard,
				DocumentType.WorkPermit,
				DocumentType.EntryPermit
			}
			)
		);
		//RULES FOR LEVEL -20- 
		_levelSettings.Add(20, new LevelSettings(
			new Rule[]{
				new PassportValidityRule(),
				new IdValidityRule(),
				new MedicalCardValidityRule(),
				new WorkPermitValidityRule(),
				new EntryPermitValidityRule(),
				new MoldovaAndRomaniaNotAllowedRule()
			},
			new DocumentType[]{
				DocumentType.Passport,
				DocumentType.ID,
				DocumentType.MedicalCard,
				DocumentType.WorkPermit,
				DocumentType.EntryPermit
			}
			)
		);
	}

	public static LevelSettings getLevelSettings(int level){
		return _levelSettings[level];
	}
}
