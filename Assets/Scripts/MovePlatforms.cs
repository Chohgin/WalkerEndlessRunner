using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatforms : MonoBehaviour
{
    public float speed = 15;
    public float minX = -49.1f;
    public float maxX = 25.0f;
    public float multiplier;

    
    private void FixedUpdate()
    {

        if (GameManager.instance.state != GameManager.eState.PLAY)
            return;

        foreach(Transform trans in transform)
        {
            trans.position += Vector3.left * Time.deltaTime * (speed * GameManager.instance.baseSpeed * GameManager.instance.ringSpeedMultiplier);

            if (trans.localPosition.x < minX)
            {
                trans.localPosition = new Vector3(maxX, trans.localPosition.y, trans.localPosition.z);
            }
        }
    }
    
    
}
