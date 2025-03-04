using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class UIButtonsBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject colorPickerButtonsContainer;

    [SerializeField] private GameObject glassesButtonsContainer;
    
    [SerializeField] private GameObject canvasButtons;

    [SerializeField] private ARCameraManager camera;
    [SerializeField] private Camera mainCamera;
    private string fileName = "Screenshot_";

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
    
    public void TakeScreenshot()
    {
        // Asegúrate de que hay una cámara asignada
        if (mainCamera == null)
        {
            Debug.LogError("No se ha asignado una cámara para la captura.");
            return;
        }

        canvasButtons.SetActive(false);

        // Configuración de RenderTexture
        int width = Screen.width;
        int height = Screen.height;

        RenderTexture renderTexture = new RenderTexture(width, height, 24);
        mainCamera.targetTexture = renderTexture;

        // Crear una textura 2D para guardar la imagen
        Texture2D screenshot = new Texture2D(width, height, TextureFormat.RGB24, false);

        // Renderizar la cámara a la RenderTexture
        mainCamera.Render();

        // Copiar los datos de la RenderTexture a la textura 2D
        RenderTexture.active = renderTexture;
        screenshot.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        screenshot.Apply();

        // Restaurar el estado original de la cámara
        mainCamera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTexture);

        // Guardar la imagen como archivo PNG
        string path = Application.persistentDataPath + "/" + fileName + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
        System.IO.File.WriteAllBytes(path, screenshot.EncodeToPNG());

        Debug.Log("Captura de pantalla guardada en: " + path);

        canvasButtons.SetActive(true);
    }
}
