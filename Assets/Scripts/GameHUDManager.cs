using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameHUDManager : MonoBehaviour
{
    public TMP_Text txtHighScore;
    public TMP_Text txtScore;

    private void Start()
    {
        txtHighScore.text = PlayerPrefs.GetInt("Score", 10000) + "";
        txtScore.text = GameManager.instance.score + "";
    }

    private void Update()
    {
        if (GameManager.instance.state != GameManager.eState.PLAY)
            return;
        //if (GameManager.instance.state == GameManager.eState.RESULTS)
            //UpdateHighScore();

        txtScore.text = GameManager.instance.score + "";
    }


    /*
    void UpdateHighScore()
    {
        if(txtHighScore.text < GameManager.instance.score)
        txtHighScore.text = txtScore.text;
    }
    */
}
