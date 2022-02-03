using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    bool isCamera1 = true;

    public GameObject[] cameras;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isCamera1 == true)
            {
                CameraSwitch(0, false);
                CameraSwitch(1, true);
                isCamera1 = false;
            }
            else
            {
                CameraSwitch(0, true);
                CameraSwitch(1, false);
                isCamera1 = true;
            }
        }
    }

    void CameraSwitch(int cameraIndex, bool onOff)
    {
        cameras[cameraIndex].SetActive(onOff);
    }
}
