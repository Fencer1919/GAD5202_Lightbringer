using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseLevel : MonoBehaviour
{
    [SerializeField] private CameraAnimationScript cameraAnimationScript;

    public static event Action onDungeonSelection;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController player))
        {
            cameraAnimationScript.IsDungeonSelectionActive = false;

            onDungeonSelection.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController player))
        {
            cameraAnimationScript.IsDungeonSelectionActive = true;

            onDungeonSelection.Invoke();
        }
    }
}
