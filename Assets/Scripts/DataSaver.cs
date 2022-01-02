using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataSaver : MonoBehaviour
{
	public static DataSaver Instance;
	public string CurrentPlayerName;
	public string BestPlayerName;
	public int BestScore;

	private void Awake()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
			return;
		}
		Instance = this;
		DontDestroyOnLoad(gameObject);

		Load();
	}

	[System.Serializable]
	class SaveData
	{
		public string CurrentPlayerName;
		public string BestPlayerName;
		public int BestScore;
	}

	public void Save()
	{
		SaveData data = new SaveData();
		data.CurrentPlayerName = CurrentPlayerName;
		data.BestPlayerName = BestPlayerName;
		data.BestScore = BestScore;

		string json = JsonUtility.ToJson(data);

		File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
	}

	public void Load()
	{
		string path = Application.persistentDataPath + "/savefile.json";
		if (File.Exists(path))
		{
			string json = File.ReadAllText(path);

			SaveData data = JsonUtility.FromJson<SaveData>(json);
			BestPlayerName = data.BestPlayerName;
			BestScore = data.BestScore;
			CurrentPlayerName = data.CurrentPlayerName;
		}
	}
}
