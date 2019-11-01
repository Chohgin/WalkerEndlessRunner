using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingManager : MonoBehaviour
{
    public int randPlacement;

    public GameObject prefRing;//prefabricated ring

    public void SpawnRing(Transform p_trans)
    {
        GameObject ring;
        ring = Instantiate(prefRing);
        ring.transform.position = Vector3.one * 1000;

        ring.transform.localScale = new Vector3(1, 1, 1);
        ring.transform.SetParent(p_trans);
        ring.transform.localPosition = Vector3.zero;
        ring.transform.localPosition = Vector3.up * Random.Range(3, 8);
        ring.transform.position = new Vector3(ring.transform.position.x, ring.transform.position.y, 0);
    }
}
