using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRule  {
	
	bool validate(DocumentsFile docs);

}
