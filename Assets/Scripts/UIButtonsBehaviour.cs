using UnityEngine;

public class UIButtonsBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject colorPickerButtonsContainer;

    [SerializeField] private GameObject glassesButtonsContainer;

    public void DisplayColorPickerContainer()
    {
        colorPickerButtonsContainer.SetActive(!colorPickerButtonsContainer.active);
    }

    public void DisplayGlassesButtonsContainer()
    {
        glassesButtonsContainer.SetActive(!glassesButtonsContainer.active);
    }
}
