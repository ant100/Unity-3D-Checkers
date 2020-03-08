using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCameraMovement : MonoBehaviour
{
    [SerializeField] private float xRotationSpeed = 1f;
    [SerializeField] private float yRotationSpeed = 1f;
    [SerializeField] private float xMovementSpeed = 1f;
    [SerializeField] private float yMovementSpeed = 1f;

    private void Update()
    {
        // Rotate camera
        if (Input.GetMouseButton(1))
        {
            RotateCamera();
        }

        // Zoom in & out
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            ZoomCameraIn();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            ZoomCameraOut();
        }

        // Translate camera
        if (Input.GetMouseButton(2))
        {
            TranslateCamera();
        }
    }

    private void RotateCamera()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x - yRotationSpeed * Input.GetAxis("Mouse Y"), transform.eulerAngles.y + xRotationSpeed * Input.GetAxis("Mouse X"), - Input.GetAxis("Mouse X"));
    }

    private void ZoomCameraIn()
    {
        Camera.main.fieldOfView -= 1;
    }

    private void ZoomCameraOut()
    {
        Camera.main.fieldOfView += 1;
    }

    private void TranslateCamera()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - Input.GetAxis("Mouse Y") * yMovementSpeed, transform.position.z + Input.GetAxis("Mouse X") * xMovementSpeed );
    }
}
