using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CharacterMovement player;
    public float baseSpeed;//increases/decreases with dashing.
    public float ringSpeedMultiplier;//increase on successful ring hop, 1:10 chance spawn
    public CameraShift cameraShift;
    public int score;
    public ScoreManager scoreManager;
    public CoinManager coinManager;
    public RingManager ringManager;
    public ParticleTrails particleTrail;

    public enum eState
    {
        COUNTDOWN,
        PLAY,
        PAUSE,
        RESULTS
    }
    public eState state;

    private void Awake()
    {
        instance = this;

    }

    private void Start()
    {
        state = eState.COUNTDOWN;
        baseSpeed = 1;
        ringSpeedMultiplier = 1;
        score = 0;
    }

    public void _Pause()
    {
        Debug.Log(state);

        switch (state)
       {
       case eState.PLAY:
            state = eState.PAUSE;
                Time.timeScale = 0;
                //Debug.Log("InsidePlay");
                break;
       case eState.PAUSE:
                state = eState.PLAY;
                Time.timeScale = 1;
               // Debug.Log("InsidePause");
                break;
        }
        
        EventSystem.current.SetSelectedGameObject(null);
        Debug.Log(state);
    }
}
