using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	//panels
	[SerializeField]
	private GameObject panelMainMenu, panelSelectLevel, panelOptions;
	private Stack<GameObject> menuStack;
	[SerializeField]
	private Text graphicLevelText;
	void OnAwake()
	{
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}
	// Use this for initialization
	void Start () {
		menuStack = new Stack<GameObject>();
		panelMainMenu.SetActive(true);
		panelSelectLevel.SetActive(false);
		panelOptions.SetActive(false);
		menuStack.Push(panelMainMenu);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void openMenu(int number)
	{
		while(menuStack.Count > 0)
		{
			menuStack.Pop().SetActive(false);
		}
		GameObject menuReference = null;
		switch(number)
		{
			case 1: menuReference = panelMainMenu;
			break;
			case 2: menuReference = panelSelectLevel;
			break;
			case 3:menuReference = panelOptions ;
			break;
			default: menuReference = panelMainMenu;
			break;
		}
		menuReference.SetActive(true);
		menuStack.Push(menuReference);
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void setGraphicLevel(float option)
	{
		string value = "";
		int opt = (int)option;
		switch(opt)
		{
			case 0: value = "Low";
			break;
			case 1: value = "Medium";
			break;
			case 2: value = "Ultra";
			break;
			default: value = "Low";
			break;
		}
		setGraphicText(value);
		string[] names = QualitySettings.names;
        int i = 0;
        while (i < names.Length) {
			Debug.Log(names[i]);
             if (value.Equals(names[i].ToLower()))
			 {
				  QualitySettings.SetQualityLevel(i, true);
				  return;
			 }
            i++;
        }
	}
	private void setGraphicText(string value)
	{
		switch(value)
		{
			case "Low": graphicLevelText.text = "Quality: Potato";
			break;
			case "Medium": graphicLevelText.text = "Quality: Decent";
			break;
			case "Ultra": graphicLevelText.text = "Quality: Phone Master Race";
			break;
			default: graphicLevelText.text = "Quality: Potato";
			break;
		}
	}
	
}
