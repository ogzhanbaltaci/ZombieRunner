using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera fpsCamera;
    [SerializeField] FirstPersonController firstPersonController;
    [SerializeField] float zoomedOutFOV = 40f;
    [SerializeField] float zoomedInFOV = 20f;
    [SerializeField] float zoomOutSensitivity = 1f;
    [SerializeField] float zoomInSensitivity = 0.4f;

    

    bool zoomedInToggle = false;
    private void OnDisable() 
    {
        ZoomOut();    
    }
   
    private void Update() 
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(zoomedInToggle == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }    
    }

    private void ZoomIn()
    {
        zoomedInToggle = true;
        fpsCamera.m_Lens.FieldOfView = zoomedInFOV;
        firstPersonController.RotationSpeed = zoomInSensitivity;
    }

    private void ZoomOut()
    {
        zoomedInToggle = false;
        fpsCamera.m_Lens.FieldOfView = zoomedOutFOV;
        firstPersonController.RotationSpeed = zoomOutSensitivity;
    }

    
}
