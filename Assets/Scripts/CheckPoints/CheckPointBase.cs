using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointBase : MonoBehaviour
{

    public MeshRenderer meshRenderer;
    public int key = 01;

    private string checkPointKey = "CheckPointKey";
    private bool checkPointActive = false;
    private void OnTriggerEnter(Collider other)
    {
        if(!checkPointActive && other.transform.tag == "Player")
        {
            CheckCheckPoint();
        }
    }

    private void CheckCheckPoint()
    {
        TurnItOn();
        SaveCheckPoint();
    }

    [NaughtyAttributes.Button]
    private void TurnItOn()
    {
        meshRenderer.material.SetColor("_EmissionColor", Color.white);
    }

     private void TurnItOff()
    {
        meshRenderer.material.SetColor("_EmissionColor", Color.grey);
    }

    private void SaveCheckPoint()
    {
       /*if (PlayerPrefs.GetInt(checkPointKey, 0) > key)
        PlayerPrefs.SetInt(checkPointKey, key);*/

        CheckPointManager.Instance.SaveCheckPoint(key);
        checkPointActive = true;
    }
}
