using UnityEngine;
using UnityEngine.UI;

public class HealthBlinkingUI : MonoBehaviour
{
    public HealthBarScript healthBar; 
    public Text blinkingText;
    public float blinkInterval = 0.5f;
    public float healthThreshold = 20f; 

    private float timer;
    private bool isBlinking = false; 

    void Start()
    {
        blinkingText.gameObject.SetActive(false); 
        timer = blinkInterval; 
    }

    void Update()
    {
        if (healthBar.GetHealth() < healthThreshold)
        {
            if (!isBlinking)
            {
                isBlinking = true;
                blinkingText.gameObject.SetActive(true);
            }
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                blinkingText.gameObject.SetActive(!blinkingText.gameObject.activeSelf);
                timer = blinkInterval; // Reset the timer
            }
        }
        else
        {
            // If health is above the threshold, stop blinking
            isBlinking = false;
            blinkingText.gameObject.SetActive(false);
        }
    }
}
