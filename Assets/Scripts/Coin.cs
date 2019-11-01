using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void Start()
    {
        //transform.localPosition = Vector3.zero;
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject != GameManager.instance.player.gameObject)
            return;

        //Debug.Log("CoinHit");
        GameManager.instance.coinManager.listCoins.Find(x => x.objCoin == gameObject).isFree = true;
        //CoinManager.CoinPool tempStore = GameManager.instance.coinManager.listCoins.Find(x => x.objCoin == gameObject);
        /*
        if(tempStore == null)
        {
            Debug.Log("tempStore is null");
        }
        */
        transform.position = Vector3.one * 1000;

        GameManager.instance.scoreManager.AddScore(1000);
    }
}
