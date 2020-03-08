using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PlayerViewPosition
{
    public Vector3 position;
    public Vector3 rotation;
    public int cameraFieldOfView;
}

public class BoardFixPosition : MonoBehaviour
{
    [Header("Board Settings")]
    [SerializeField] private PlayerViewPosition blackPlayer;
    [SerializeField] private PlayerViewPosition whitePlayer;
    [SerializeField] private PlayerViewPosition boardCenter;

    [Header("Camera Settings")]
    [SerializeField] private Vector3 cameraBasePosition;
    [SerializeField] private Vector3 cameraBaseRotation;


    public void SetBlackPlayerPosition()
    {
        transform.position = blackPlayer.position;
        transform.eulerAngles = blackPlayer.rotation;
        Camera.main.fieldOfView = blackPlayer.cameraFieldOfView;
        Camera.main.transform.position = cameraBasePosition;
        Camera.main.transform.eulerAngles = cameraBaseRotation;
    }

    public void SetWhitePlayerPosition()
    {
        transform.position = whitePlayer.position;
        transform.eulerAngles = whitePlayer.rotation;
        Camera.main.fieldOfView = blackPlayer.cameraFieldOfView;
        Camera.main.transform.position = cameraBasePosition;
        Camera.main.transform.eulerAngles = cameraBaseRotation;
    }

    public void SetBoardCenterPosition()
    {
        transform.position = boardCenter.position;
        transform.eulerAngles = boardCenter.rotation;
        Camera.main.fieldOfView = boardCenter.cameraFieldOfView;
        Camera.main.transform.position = cameraBasePosition;
        Camera.main.transform.eulerAngles = cameraBaseRotation;
    }
}
