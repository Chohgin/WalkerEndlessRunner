using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShift : MonoBehaviour
{
    public int cameraCount;
    public bool allowCameraMove;
    public List<GameObject> listCameraPositions;

    IEnumerator LerpFromTo(Vector3 pos1, Vector3 pos2, float duration)
    {
        
            transform.SetParent(listCameraPositions[cameraCount].gameObject.transform);

            for (float t = 0f; t < duration; t += Time.deltaTime)
            {
                transform.position = Vector3.Lerp(pos1, pos2, t / duration);
                transform.rotation = Quaternion.Lerp(listCameraPositions[cameraCount-1].transform.rotation,
                listCameraPositions[cameraCount].transform.rotation, t / duration);
                yield return 0;
            }

            transform.position = pos2;
            transform.rotation = Quaternion.Lerp(listCameraPositions[cameraCount-1].transform.rotation,
                listCameraPositions[cameraCount].transform.rotation, 1.0f);
        
       
    }
    public void Start()
    {
        cameraCount = 0;
        listCameraPositions = new List<GameObject>();
        listCameraPositions.Add(GameObject.Find("CameraStart")); //0
        listCameraPositions.Add(GameObject.Find("CameraPointB"));//1
        listCameraPositions.Add(GameObject.Find("CameraPointC"));//2
        listCameraPositions.Add(GameObject.Find("CameraPointD"));//3
        listCameraPositions.Add(GameObject.Find("CameraPointE"));//4
        listCameraPositions.Add(GameObject.Find("CameraPointF"));//5
        listCameraPositions.Add(GameObject.Find("CameraPointG"));//6
        listCameraPositions.Add(GameObject.Find("CameraPointH"));//7
        listCameraPositions.Add(GameObject.Find("CameraPointI"));//8
        listCameraPositions.Add(GameObject.Find("CameraEnd"));   //9

        /*
        foreach(GameObject obj in listCameraPositions)
        {
            Debug.Log(obj);
        }
        */
        transform.SetParent(listCameraPositions[cameraCount].gameObject.transform);
        

    }

    public void AdjustCamera()
    {
        if (cameraCount < 9)
        {
            cameraCount++;
            StartCoroutine(LerpFromTo(listCameraPositions[cameraCount - 1].transform.position,
                listCameraPositions[cameraCount].transform.position, 1.0f));
            GameManager.instance.particleTrail.IncreaseTrail();
        }
    }

    public void SetallowCameraMove()
    {
        Debug.Log("adjustCamera: " + allowCameraMove);
        allowCameraMove = !allowCameraMove;
    }
    public bool GetallowCameraMove()
    {
        return allowCameraMove;
    }
     
}
