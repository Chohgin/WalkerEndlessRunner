using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    float tmpScore;

    private void Start()
    {


        tmpScore = 0;
    }



    void Update()
    {
        tmpScore += Time.deltaTime * 100;
        GameManager.instance.score = (int)tmpScore;
    }

    public void AddScore (int p_val)
    {
        tmpScore += p_val; 
    }
    public void SaveScore()
    {

        PlayerPrefs.SetInt("Score", GameManager.instance.score);
        PlayerPrefs.Save();
    }
}
