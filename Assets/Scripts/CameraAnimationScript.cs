using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraAnimationScript : MonoBehaviour
{

    public CinemachineVirtualCamera cinemachineVirtualCamera;


    private bool isTabActive = false;

    void Awake()
    {
        PlayerController.onToggleAttributeTab += ToggleAttribute;
    }

    public void ToggleAttribute()
    {
        if(!isTabActive)
        {
            cinemachineVirtualCamera.m_Lens.OrthographicSize = 4;
            cinemachineVirtualCamera.GetComponentInChildren<CinemachineFramingTransposer>().m_TrackedObjectOffset = new Vector3(4,0,0);

            isTabActive = true;
        }
        else
        {
            cinemachineVirtualCamera.m_Lens.OrthographicSize = 10;
            cinemachineVirtualCamera.GetComponentInChildren<CinemachineFramingTransposer>().m_TrackedObjectOffset = new Vector3(0,0,0);

            isTabActive = false;
        }

    }
}
