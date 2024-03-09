using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Button button;

    private bool buttonPressed = false;

    public Controller control;

    private void Start()
    {
        button = GetComponent<Button>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerId == -1 && button.interactable) 
        {
            control.isShooting = true;
            buttonPressed = true;
            Debug.Log("Button Pressed");
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerId == -1 && buttonPressed) 
        {
            control.isShooting = false;
            buttonPressed = false;
            Debug.Log("Button Released");
        }
    }
}
