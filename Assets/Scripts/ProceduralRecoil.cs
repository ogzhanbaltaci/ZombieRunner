using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;


public class ProceduralRecoil : MonoBehaviour
{
    Vector3 currentRotation, targetRotation, targetPosition, currentPosition, initialGunPosition, initialGunRotation;

    public Transform cam;

    [SerializeField] float recoilX;
    [SerializeField] float recoilY;
    [SerializeField] float recoilZ;

    [SerializeField] float kickBackZ;

    public float snappiness, returnAmount;
    void Start() 
    {
        initialGunPosition = transform.localPosition;
        initialGunRotation = new Vector3(0.256f, -94.928f, 3.267f);
    }

    void Update()
    {
        RotationBack();
        Back();

    }

    private void RotationBack()
    {
        targetRotation = Vector3.Lerp(targetRotation, initialGunRotation, Time.deltaTime * returnAmount);
        currentRotation = Vector3.Slerp(currentRotation, targetRotation, Time.fixedDeltaTime * snappiness);
        transform.localRotation = Quaternion.Euler(currentRotation);
        cam.localRotation = Quaternion.Euler(currentRotation);
    }

    private void Back()
    {
        targetPosition = Vector3.Lerp(targetPosition, initialGunPosition, Time.deltaTime * returnAmount);
        currentPosition = Vector3.Lerp(currentPosition, targetPosition, Time.deltaTime * snappiness);
        transform.localPosition = currentPosition;
    }

    public void Recoil()
    {
        targetPosition -= new Vector3(0, 0, kickBackZ);
        targetRotation += new Vector3(recoilX, Random.Range(-recoilY, recoilY), Random.Range(-recoilZ, recoilZ));
    }
}
