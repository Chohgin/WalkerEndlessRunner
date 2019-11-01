using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
   
    // Update is called once per frame
    private void Update()
    {
        if(GameManager.instance.state == GameManager.eState.RESULTS)
        {
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene("game");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == GameManager.instance.player.gameObject)
        {
            GameManager.instance.state = GameManager.eState.RESULTS;
            GameManager.instance.scoreManager.SaveScore();
            SceneManager.LoadScene("DeathScreen");
        }
    }

    
}
