using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerRingTrigger : MonoBehaviour
{
    public int cameraCount;
    public bool adjustCamera;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != GameManager.instance.player.gameObject)
            return;

        Destroy(transform.parent.gameObject);
        GameManager.instance.cameraShift.SetallowCameraMove();
        
        if (GameManager.instance.cameraShift.GetallowCameraMove())
        {
            GameManager.instance.cameraShift.AdjustCamera();
        }
        GameManager.instance.ringSpeedMultiplier += 0.2f;
    }
}
