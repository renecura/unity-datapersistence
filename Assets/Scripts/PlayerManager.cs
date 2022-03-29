using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public string playerName;
    public int bestScore = 0;
    public string bestPlayer = "???";

    void Awake(){
        if(Instance != null){
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    public static void SaveData(){
        BestScoreData data = new BestScoreData();
        data.player = Instance.bestPlayer;
        data.score = Instance.bestScore;

        string json = JsonUtility.ToJson(data);  
        File.WriteAllText(Application.persistentDataPath + "/bestScore.json", json);
    }

    void LoadData(){
        string path = Application.persistentDataPath + "/bestScore.json";
        
        if (File.Exists(path)){
            string json = File.ReadAllText(path);
            BestScoreData data = JsonUtility.FromJson<BestScoreData>(json);
            Instance.bestScore = data.score;
            Instance.bestPlayer = data.player;
        }        
    }
}

[System.Serializable]
class BestScoreData {
    public string player;
    public int score;
}
