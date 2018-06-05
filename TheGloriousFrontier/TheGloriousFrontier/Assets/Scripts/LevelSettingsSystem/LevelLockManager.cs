using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLockManager : MonoBehaviour {

	[SerializeField]
	private LevelFinishedPanelController levelFinishedController;
	void Awake () {
		string level = "level " + CurrentGameInfo.CurrentLevel;
		if(PlayerPrefs.GetInt(level, -1) == -1)
		{
			PlayerPrefs.SetInt(level,0);
		}
	}
	void Start()
	{
		levelFinishedController.OnStartNextLevel += GoToNext;
	}
	private void GoToNext()
	{
		int current = CurrentGameInfo.CurrentLevel;
		if(current < 20)
		{
			CurrentGameInfo.CurrentLevel = current + 1;
			SceneManager.LoadScene("MainLevelNewScene");
		}else if(current == 20)
		{
			SceneManager.LoadScene("MenuScene");
		}
	}
	public void SavePointsForLevel(int points)
	{
		string level = "level " + CurrentGameInfo.CurrentLevel;
		int n = PlayerPrefs.GetInt(level, -1);
		if(n != points)
		{
			n = points;
			PlayerPrefs.SetInt(level,n);
		}
	}
}
