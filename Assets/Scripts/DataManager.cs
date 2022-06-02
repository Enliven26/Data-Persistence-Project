using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public bool isPause = false;
    public Player currentPlayer;
    public List<Player> highscoreList;
    public System.Action<Player> changeBestScore;

    // Start is called before the first frame update

    public class Player
    {
        public string Name;
        public int Score;

    }


    [System.Serializable]
    public class SaveData
    {
        public List<string> nameList;
        public List<int> scoreList;

  
    }
    
    private void Awake()
    {
       

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        else
        {
            Destroy(gameObject);
        }

        LoadData();


    }

    void Start()
    {
        currentPlayer = new Player();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void editPlayer(string name, int score)
    {
        currentPlayer.Name = name;
        currentPlayer.Score = score;
    }

    public void updateScore()
    {
        

        int nameIdx = searchNameIdx(currentPlayer.Name);

        if (nameIdx != -1)
        {
            if (highscoreList[nameIdx].Score < currentPlayer.Score)
            {
                highscoreList.RemoveAt(nameIdx);
            }

            else
            {
                currentPlayer.Score = -1;
            }
        }

        int i = highscoreList.Count;

        while (i - 1 >= 0)
        {
            if (currentPlayer.Score <= highscoreList[i - 1].Score)
            {
                break;
            }

            i--;

        }


        if (i <= 4)
        {
            
            Player newPlayerRecord = new Player();

            newPlayerRecord.Name = currentPlayer.Name;

            if (currentPlayer.Name == null)
            {
                newPlayerRecord.Name = "Unknown";
            }
            newPlayerRecord.Score = currentPlayer.Score;

            highscoreList.Insert(i, newPlayerRecord);

            if (highscoreList.Count > 5)
            {
                highscoreList.RemoveAt(5);
            }

            Save();

        }
        
    }

    public int searchNameIdx(string name)
    {
        for(int i = 0; i < highscoreList.Count; i++)
        {
            if(highscoreList[i].Name == name)
            {
                return i;
            }
        }

        return -1;
    }

    public void LoadData()
    {
        highscoreList = new List<Player>();

        string path = Application.persistentDataPath + "/saveData.json";

        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(jsonData);

            for (int i = 0; i < data.nameList.Count; i++)
            {
                Player record = new Player();
                record.Name = data.nameList[i];
                record.Score = data.scoreList[i];

                highscoreList.Add(record);
            }

        }

          

        
    }
    
    public void Save()
    {
        SaveData data = new SaveData();
        data.nameList = new List<string>();
        data.scoreList = new List<int>();
        

        foreach (Player player in highscoreList)
        {
            data.nameList.Add(player.Name);
            data.scoreList.Add(player.Score);
        }
        

        string jsonData = JsonUtility.ToJson(data);
        Debug.Log(jsonData);
        
        File.WriteAllText(Application.persistentDataPath + "/saveData.json", jsonData);
        
    }
}
