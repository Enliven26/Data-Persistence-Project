using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public bool isPause = false;
    public Player currentPlayer;
    // Start is called before the first frame update

    public class Player
    {
        public string Name;
        public int Score;
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
}
