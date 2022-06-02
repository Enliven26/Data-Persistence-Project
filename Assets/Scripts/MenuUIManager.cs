using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
# endif

public class MenuUIManager : SceneFlow
{
    public Text startButtonText;
    public InputField nameInput;
    // Start is called before the first frame update
    void Start()
    {
        if (DataManager.Instance != null)
        {
            {
                if (DataManager.Instance.isPause)
                {
                    startButtonText.text = "Continue";
                    
                }

                else
                {
                    startButtonText.text = "Start";
                }
            }
            
        }

        else
        {
            startButtonText.text = "Start";
        }

        nameInput.text = DataManager.Instance.currentPlayer.Name;
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SeeHighScore()
    {
        SceneManager.LoadScene("highscore");
    }

    public void OnChangeName()
    {

        DataManager.Instance.currentPlayer.Name = nameInput.text;

        Time.timeScale = 1;
        DataManager.Instance.isPause = false;
        
      
       
    }

    public void Quit()
    {
        DataManager.Instance.Save();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();

# endif
    }
  
}
