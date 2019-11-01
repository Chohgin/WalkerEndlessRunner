using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClamps : MonoBehaviour
{
    public bool cameraBounds;
    public float minCameraPos;
    public float maxCameraPos;
    // Update is called once per frame
    void Update()
    {
        if (cameraBounds)
        {
            transform.position = new Vector3(transform.position.x,
                Mathf.Clamp(transform.position.y, minCameraPos, maxCameraPos), transform.position.z);
        }
    }
}
