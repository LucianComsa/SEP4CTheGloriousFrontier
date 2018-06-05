using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Document {
	public DocumentType docType {get; protected set;}
	
	public Document(DocumentType type)
	{
		docType =  type;
	}

	
	public override bool Equals(object obj)
	{	
		if (obj == null || GetType() != obj.GetType())
		{
			return false;
		}
		return this.docType.Equals( ((Document) obj).docType );
	}
	
	
	
}
