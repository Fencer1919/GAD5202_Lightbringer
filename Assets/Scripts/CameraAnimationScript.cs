using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraAnimationScript : MonoBehaviour
{

    public CinemachineVirtualCamera cinemachineVirtualCamera;
    public CinemachineFramingTransposer cinemachineFramingTransposer;


    private bool isTabActive = false;
    private bool isDungeonSelectionActive = false;

    public bool IsDungeonSelectionActive { get => isDungeonSelectionActive; set => isDungeonSelectionActive = value; }

    void Awake()
    {
        cinemachineFramingTransposer = cinemachineVirtualCamera.GetComponentInChildren<CinemachineFramingTransposer>();

        PlayerController.onToggleAttributeTab += ToggleAttribute;
        ChooseLevel.onDungeonSelection += OnDungeonSelection;
    }

    private void OnDungeonSelection()
    {
        if (!IsDungeonSelectionActive)
        {
            cinemachineVirtualCamera.m_Lens.OrthographicSize = 4;
            cinemachineFramingTransposer.m_TrackedObjectOffset = new Vector3(4, 0, 0);

            IsDungeonSelectionActive = true;
        }
        else
        {
            cinemachineVirtualCamera.m_Lens.OrthographicSize = 10;
            cinemachineFramingTransposer.m_TrackedObjectOffset = new Vector3(0, 0, 0);

            IsDungeonSelectionActive = false;
        }
    }

    public void ToggleAttribute()
    {
        if(!isTabActive)
        {
            cinemachineVirtualCamera.m_Lens.OrthographicSize = 4;
            cinemachineFramingTransposer.m_TrackedObjectOffset = new Vector3(4,0,0);

            isTabActive = true;
        }
        else
        {
            cinemachineVirtualCamera.m_Lens.OrthographicSize = 10;
            cinemachineFramingTransposer.m_TrackedObjectOffset = new Vector3(0,0,0);

            isTabActive = false;
        }

    }
}
