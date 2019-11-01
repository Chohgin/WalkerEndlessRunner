using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    private float timeLeft = 3;
    TMP_Text txtCountDown;
    void Start()
    {
        GameManager.instance.state = GameManager.eState.COUNTDOWN;
        txtCountDown = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft < 0 && GameManager.instance.state == GameManager.eState.COUNTDOWN)
            GameManager.instance.state = GameManager.eState.PLAY;

    }

    public void __ChangeText(string p_val)
    {
        txtCountDown.text = p_val;
    }
}
