using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    public Transform crosshairTransform; // The crosshair's transform
    public Camera fpsCamera; // Reference to the first-person camera
    private RectTransform crosshairRectTransform;


    private void Start()
    {
        crosshairRectTransform = GetComponent<RectTransform>();

    }

    private void Update()
    {
        UpdateCrosshairPosition();
    }

    private void UpdateCrosshairPosition()
    {
        crosshairRectTransform.position = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);

        // Cast a ray from the camera through the center of the screen
        Ray ray = fpsCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Move the crosshair to the point where the ray hits an object
            crosshairTransform.position = hit.point;
        }
        else
        {
            // If the ray doesn't hit anything, place the crosshair at a default distance
            crosshairTransform.position = ray.GetPoint(10f);
        }
    }
}
