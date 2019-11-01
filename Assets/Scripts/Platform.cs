using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MovePlatforms
{
    //put onto individual platforms


    private Transform t;
    private Transform player;
    public float placeRingCount = 9;
    public float placeCoinCount = 5;
    //private bool touched;//if player has touched the platform.
    /*
    private void Awake()
    {
        
        t = this.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        touched = false;
        
    }
    private void OnCollisionEnter()
    {
        touched = true;
    }
    
    private void Update()
    {
        if (GameManager.instance.state != GameManager.eState.PLAY)
            return;

        if (Distance() > 30.0f && touched)
        {
            t.localPosition = new Vector3(player.localPosition.x + 28.0f, t.localPosition.y, t.localPosition.z);
            GameManager.instance.coinManager.SpawnCoin(t);
            touched = false;
        }
    }
    */

    private void FixedUpdate()
    {

        if (GameManager.instance.state != GameManager.eState.PLAY)
            return;



        foreach (Transform trans in transform)
        {
            trans.position += Vector3.left * Time.deltaTime * (speed * GameManager.instance.baseSpeed * GameManager.instance.ringSpeedMultiplier);

            if (trans.localPosition.x < minX)
            {
                Debug.Log("Trans: " + trans.name + " moved");
                if (trans.transform.childCount > 0)
                {
                   Destroy(trans.GetChild(0).gameObject);
                }
                if (trans.transform.childCount > 1)
                {
                    Destroy(trans.GetChild(0).gameObject);
                    Destroy(trans.GetChild(1).gameObject);

                }
                trans.localPosition = new Vector3(maxX, trans.localPosition.y, trans.localPosition.z);
                if (Random.Range(0, placeRingCount--) <= 0)
                {
                    GameManager.instance.ringManager.SpawnRing(trans);
                    placeRingCount = 9;
                    //
                }
                else if(Random.Range(0, placeCoinCount--)<=0)
                {
                    GameManager.instance.coinManager.SpawnCoin(trans);
                    placeCoinCount = 5;
                }
            }
        }



    }

    /*
    private float Distance()
    {
        float distance;
        distance =  Vector3.Distance(t.position, player.position);
        //Debug.Log(this.name + ": " + distance);
        return distance;
    }
    */
}
