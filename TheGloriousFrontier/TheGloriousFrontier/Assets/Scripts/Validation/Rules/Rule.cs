using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rule : IRule {
	private string label;
	public string Label{get {return label;} protected set{label = value;}}

    public abstract bool validate(DocumentsFile docs);
}
