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
        Debug.Log(DataManager.Instance.currentPlayer.Name);
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
        Debug.Log(DataManager.Instance.currentPlayer.Name);
       
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();

# endif
    }
  
}
