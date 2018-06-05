using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RuleListFiller : MonoBehaviour {

	public event Action OnRulesPanelClosed = delegate { };

	// Use this for initialization
	void Start () {
		PopulateUI(
				RuleBook
				.getLevelSettings(CurrentGameInfo.CurrentLevel)
				.Rules
		);
	}
	
	private void PopulateUI(Rule[] rules){
		Text textBox = GetComponent<Text>();
		int i = 1;

		foreach(Rule rule in rules){
			textBox.text += i++.ToString() + ") " + rule.Label + "\r\n\r\n";
		}

		
	}

	public void TriggerOnRulesPanelClosed(){
		OnRulesPanelClosed();
	}
}
