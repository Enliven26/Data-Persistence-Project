using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreUI : SceneFlow
{
    public Text record;
    // Start is called before the first frame update
    void Start()
    {
        foreach(DataManager.Player player in DataManager.Instance.highscoreList)
        {
            Text currentRecord = Instantiate(record, transform);
            currentRecord.text = player.Name + " : " + player.Score;
        }

        if (DataManager.Instance.highscoreList.Count == 0)
        {
            Text currentRecord = Instantiate(record, transform);
            currentRecord.text = "No Record";
        }
    }

}
