using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject prefCoin;

    public class CoinPool
    {
        public GameObject objCoin;
        public bool isFree;
    }

    public List<CoinPool> listCoins;

    public class ObjectPool
    {
        public GameObject objPool;
        public bool isFree;
    }
    public List<ObjectPool> listPool;
    public GameObject[] listCoinPatterns;

    public GameObject[] arrCoinPatterns;//used to allow multiple coin patterns
    private int countArrCoin = 3; //keeps count of spawned coins
    private int numPatterns = 3;
    /*
    public class PlatformCoinPattern
    {
        public GameObject platform;
        public GameObject coinPattern;
    }
    */
    //List<PlatformCoinPattern> listPlatformCoinPatterns;

    private void Start()
    {
        //listPlatformCoinPatterns = new List<PlatformCoinPattern>();
        listCoins = new List<CoinPool>();
        listPool = new List<ObjectPool>();
        arrCoinPatterns = new GameObject[numPatterns];//adjust later to be dynamic


    }
    /*
    IEnumerator SetPosition(GameObject p_go, Transform p_trans)
    {
        GameObject go = p_go;

        go.transform.localScale = new Vector3(1, 1, 1);
        go.transform.SetParent(p_trans);

        yield return new WaitForFixedUpdate();

        go.transform.localPosition = Vector3.zero;

        go.transform.localPosition += Vector3.up * 4;

        go.transform.position = new Vector3(go.transform.position.x,
           go.transform.position.y, GameManager.instance.player.transform.position.z);

    }
    */

    public void SpawnCoin(Transform p_trans)
    {
        
       
        Debug.Log("p_trans: " + p_trans);
        GameObject patternObj = FreePattern(p_trans);//this is setting it back to null before use
        if (patternObj != null)
            FreeCoins(patternObj.transform);


        GameObject go = GetPattern(p_trans);//this needs to be altered.***********
        if (go != null)
            GetCoins(go.transform);

        //go.transform.localScale = Vector3.one;
        go.transform.SetParent(p_trans);//it didnt like this for some reason
        go.transform.localPosition = Vector3.zero;
        go.transform.localPosition += new Vector3(0, 4, 0);
        //go.transform.localRotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
        go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, GameManager.instance.player.transform.position.z);
        //Debug.Log("End of Spawn Coin");

    }

    public GameObject FreePattern(Transform p_trans)
    {
        ObjectPool op;        //Debug.Log("Inside Free Pattern");

        if (p_trans.childCount <= 0)
            return null;

        if (p_trans.GetChild(0).name == "Ring(Clone)")
            op = listPool.Find(x => x.objPool == p_trans.GetChild(1).gameObject);
        else
            op = listPool.Find(x => x.objPool == p_trans.GetChild(0).gameObject);


        if (op != null)
        {
            op.objPool.transform.position = Vector3.one * 1000;
            //op.objPool.transform.DetachChildren();
            op.isFree = true;
        }
        else
            return null;
        //Debug.Log("Returning Free Pattern");

        return op.objPool;
    }

    public void FreeCoins(Transform p_trans)
    {
        //Debug.Log("Inside Free Coin");

        foreach (Transform trans in p_trans)
        {
            if (transform.childCount <= 0)
                continue;

            CoinPool cp = listCoins.Find(x => x.objCoin == transform.GetChild(0).gameObject);
            if (cp != null)
            {
                cp.objCoin.transform.position = Vector3.one * 1000;
                cp.isFree = true;
            }
        }
        //Debug.Log("End of Free Coin");

    }

    GameObject GetPattern(Transform p_trans)
    {
        ObjectPool op = null;
        //Debug.Log("Inside Get Pattern");
      
            op = listPool.Find(x => x.isFree);
        //Debug.Log("op: " + op.objPool);
        if (op == null)
        {
            //Debug.Log("line 148 ArrCoinPatterns[" + countArrCoin + "]: " + arrCoinPatterns[countArrCoin]);

            //Debug.Log("Inside arrCoin null If.");
            GameObject objPattern = null;
            objPattern = listCoinPatterns[Random.Range(0, listCoinPatterns.Length)];
            op = new ObjectPool();
            op.objPool = Instantiate(objPattern);
            op.objPool.transform.localScale = Vector3.one;
            op.objPool.transform.SetParent(p_trans);
            op.objPool.transform.localPosition = Vector3.zero;
            op.isFree = false;
            listPool.Add(op);
            

        }
        else
        {
            //Debug.Log("op: " + op.objPool);
            op.objPool.transform.SetParent(p_trans);
            op.objPool.transform.localPosition = Vector3.zero;
            op.isFree = false;
        }

        //Debug.Log("Returning Get Pattern");

        return op.objPool;
    }

    void GetCoins(Transform p_trans)
    {
        //Debug.Log("Inside Get Coin");

        foreach (Transform trans in p_trans)
        {
            CoinPool cp = listCoins.Find(x => x.isFree);



            cp = new CoinPool();
            cp.objCoin = Instantiate(prefCoin);
            cp.objCoin.transform.SetParent(trans);
            cp.objCoin.transform.localPosition = Vector3.zero;
            cp.isFree = false;
            listCoins.Add(cp);
        }
        //Debug.Log(listCoins[0]);

        //Debug.Log(listCoins[0].objCoin);
        //Debug.Log("End of Coin");


    }
}
