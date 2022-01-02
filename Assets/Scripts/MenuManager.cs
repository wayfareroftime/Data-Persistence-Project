using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
	public InputField PlayerNameField;
	public Text BestScoreText;

	public void Start()
	{
		string playerName = DataSaver.Instance.BestPlayerName;
		int bestScore = DataSaver.Instance.BestScore;
		BestScoreText.text = $"Best Score: {playerName} : {bestScore}";

		if (DataSaver.Instance.CurrentPlayerName != null)
		{
			PlayerNameField.text = DataSaver.Instance.CurrentPlayerName;
		}
	}
	public void StartNew()
	{
		SceneManager.LoadScene(1);
	}

	public void Exit()
	{
#if UNITY_EDITOR
		EditorApplication.ExitPlaymode();
#else
Application.Quit();
#endif
		DataSaver.Instance.Save();
	}

	public void SavePlayerName()
	{
		DataSaver.Instance.CurrentPlayerName = PlayerNameField.text;
	}
}
