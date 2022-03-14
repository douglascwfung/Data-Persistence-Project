using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreScript : MonoBehaviour
{


    public static ScoreScript Instance; 
    public string currentPlayer;
    public string bestPlayer;
    public int bestScore;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore(); 
    }

    [System.Serializable]
    class SaveData
    {
        public string bestPlayer;
        public int bestScore;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.bestPlayer = bestPlayer;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);
        //Debug.Log(Application.persistentDataPath );
    
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayer = data.bestPlayer;
            bestScore = data.bestScore;

            Debug.Log("LoadScore - bestPlayer:" + bestPlayer);
            Debug.Log("LoadScore - bestScore:" + bestScore);

        }
    }


}
