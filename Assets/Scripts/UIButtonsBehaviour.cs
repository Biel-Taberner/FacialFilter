using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class UIButtonsBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject colorPickerButtonsContainer;

    [SerializeField] private GameObject glassesButtonsContainer;

    [SerializeField] private ARCameraManager camera;

    public void DisplayColorPickerContainer()
    {
        colorPickerButtonsContainer.SetActive(!colorPickerButtonsContainer.active);
    }

    public void DisplayGlassesButtonsContainer()
    {
        glassesButtonsContainer.SetActive(!glassesButtonsContainer.active);
    }

    public void ChangeCameraFacingDirection()
    {
        camera.requestedFacingDirection = (camera.currentFacingDirection == CameraFacingDirection.User)
            ? CameraFacingDirection.World
            : CameraFacingDirection.User;
    }
}
