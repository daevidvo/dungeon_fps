using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAimController : MonoBehaviour
{
    public Transform gunTransform; // Reference to the gun's transform
    public Transform crosshairTransform; // Reference to the crosshair's transform
    private Vector3 initialGunPosition;
    public Vector3 fixedGunRotation; // The fixed rotation you want to maintain for the gun


    private void Start()
    {
        initialGunPosition = gunTransform.localPosition;
    }

    private void Update()
    {
        AimGunAtCrosshair();
    }

    private void AimGunAtCrosshair()
    {
        Vector3 directionToCrosshair = crosshairTransform.position - gunTransform.position;
        Quaternion targetRotation = Quaternion.LookRotation(directionToCrosshair);
        targetRotation *= Quaternion.Euler(fixedGunRotation);
        gunTransform.rotation = targetRotation;
        gunTransform.localPosition = initialGunPosition; // Reset the gun's local position
    }
}
