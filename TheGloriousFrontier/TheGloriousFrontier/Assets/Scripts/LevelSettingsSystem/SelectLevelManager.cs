using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevelManager : MonoBehaviour 
{	
	[SerializeField]
	private List<Button> buttons;
	void Awake()
	{
		if(PlayerPrefs.GetInt("level 1", -1) == -1)
		{
			PlayerPrefs.SetInt("level 1",0);
			Debug.Log("Set level 1");
		}
	}
	void Start()
	{
		SetUpButtons();
	}
	private void SetUpButtons()
	{
		foreach(Button b in buttons)
		{
			if(b.GetComponentInChildren<Text>() != null)
			{
				string buttonText = b.GetComponentInChildren<Text>().text;
				if(ShouldUnlock(buttonText))
				{
					b.interactable = true;
				}else
				{ b.interactable = false;}

			}
		}
	}
	private bool ShouldUnlock(string level)
	{
		if(PlayerPrefs.GetInt(level.ToLower(), -1) != -1)
		{
			return true;
		}else return false;
	}
	public void SetLevel(int level)
	{
		CurrentGameInfo.CurrentLevel = level;
		SceneManager.LoadScene("MainLevelNewScene");
		Debug.Log("done");
	}
}
