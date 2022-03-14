using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public Text UserName;
    public Text BestScoreText;
    
    private void Start()
    {
        //ScoreScript.Instance.bestPlayer ="test";        
        //ScoreScript.Instance.bestScore =10;        

        // Debug.Log("1"+ScoreScript.Instance.bestPlayer);
        // Debug.Log("2"+ScoreScript.Instance.bestScore);

        if (ScoreScript.Instance.bestPlayer is null || ScoreScript.Instance.bestPlayer.Length ==0 ) {
            BestScoreText.text = "Best Score";            
        } else {
            BestScoreText.text = "Best Score : " + ScoreScript.Instance.bestPlayer + " : " + ScoreScript.Instance.bestScore;            
        }


    }

    public void StartNew()
    {
        //Debug.Log("UserName.text:" + UserName.text );
        ScoreScript.Instance.currentPlayer = UserName.text;        
        //MainManager.Instance.PlayerName = UserName.text;
        // ScoreScript.Instance.bestPlayer ="test";        
        // ScoreScript.Instance.bestScore =10;        
        SceneManager.LoadScene(1);
    }

  public void Exit()
    {
        //MainManager.Instance.SaveColor(); 

        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); // original code to quit Unity player
        #endif
        }


    public void SaveColorClicked()
    {
        //MainManager.Instance.SaveColor();
    }

    public void LoadColorClicked()
    {
        //MainManager.Instance.LoadColor();
        //ColorPicker.SelectColor(MainManager.Instance.TeamColor);
    }

}
