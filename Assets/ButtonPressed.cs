using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CustomButton : MonoBehaviour
{
    public Controller control;
    private bool buttonPressed = false;
    private bool canShoot = true;

    public void PressButton()
    {
        if (!buttonPressed && canShoot)
        {
            control.isShooting = true;
            buttonPressed = true;
            Debug.Log("Button Pressed");

            StartCoroutine(DelayBeforeRelease());
        }
    }

    IEnumerator DelayBeforeRelease()
    {
        canShoot = false;
        yield return new WaitForSeconds(0.1f);
        ReleaseButton();
        canShoot = true;
    }

    public void ReleaseButton()
    {
        control.isShooting = false;
        buttonPressed = false;
        Debug.Log("Button Released");
    }
}
