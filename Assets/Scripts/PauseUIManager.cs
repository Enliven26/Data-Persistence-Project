using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseUIManager : SceneFlow
{
    public GameObject pauseButton;
    public GameObject pauseMenu;
    public Text bestScoreText;

    private void Awake()
    {
        if (DataManager.Instance != null)
        {
            DataManager.Instance.changeBestScore += writeBestScore;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        showPauseUI();
        
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickPause()
    {

        DataManager.Instance.isPause = true;
        Time.timeScale = 0;
        showPauseUI();
    }

    public void ContinuePlay()
    {

        DataManager.Instance.isPause = false;
        Time.timeScale = 1;
        showPauseUI();
    }

    private void showPauseUI()
    {
        if (DataManager.Instance != null)

        { 
            if (DataManager.Instance.isPause)
            {
                pauseButton.SetActive(false);
                pauseMenu.SetActive(true);
            }

            else
            {
                pauseButton.SetActive(true);
                pauseMenu.SetActive(false);
            }
         
        }

    }

    public void writeBestScore(DataManager.Player bestPlayer)
    {
        if (bestPlayer != null)
        {
            bestScoreText.text = "Best Score : " + bestPlayer.Name
                + " : " + bestPlayer.Score;
        }
        
    }

    private void OnDestroy()
    {
        DataManager.Instance.changeBestScore -= writeBestScore;
    }

}
