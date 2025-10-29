using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public CarController carController;

    public enum ButtonType { Accelerate, Brake, Left, Right }
    public ButtonType buttonType;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!carController) return;

        switch (buttonType)
        {
            case ButtonType.Accelerate: carController.OnAccelerateDown(); break;
            case ButtonType.Brake: carController.OnBrakeDown(); break;
            case ButtonType.Left: carController.OnLeftDown(); break;
            case ButtonType.Right: carController.OnRightDown(); break;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!carController) return;

        switch (buttonType)
        {
            case ButtonType.Accelerate: carController.OnAccelerateUp(); break;
            case ButtonType.Brake: carController.OnBrakeUp(); break;
            case ButtonType.Left: carController.OnLeftUp(); break;
            case ButtonType.Right: carController.OnRightUp(); break;
        }
    }
}
