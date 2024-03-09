using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthBarScript : MonoBehaviour
{

    public bool isInvincible = false; // Flag to track invincibility
    private float invincibilityDuration = 0f; // Duration of invincibility
    private float invincibilityTimer = 0f; // Timer for invincibility

    public Text invincibilityTimerText;

    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public int startHealth;
    public float DisplayHealth;

    public AudioClip DestroySound;
    private bool hasPlayedDestroySound = false;
    private AudioSource audioSource;
    public Canvas GameOverCanvas;
    private void Start()
    {
        GameOverCanvas.enabled = false;
        startHealth = 100;
        SetHealth(startHealth);
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        if (slider.value == 0 && !hasPlayedDestroySound) // Check if the destroy sound has not been played yet
        {
            PlayDestroySound();
            hasPlayedDestroySound = true; // Set the flag to true to indicate that the sound has been played
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name != "SampleScene" || scene.name == "Future")
            {
                GameOverCanvas.enabled = true;
            }
            
            else
            {
                SceneManager.LoadScene("Retro");
            }

           
        }

        if (isInvincible)
        {
            invincibilityTimer -= Time.deltaTime;

            // Disable invincibility if timer runs out
            if (invincibilityTimer <= 0f)
            {
                isInvincible = false;
            }
            UpdateInvincibilityTimerText();
        }
    }

    void UpdateInvincibilityTimerText()
    {
        invincibilityTimerText.text = Mathf.CeilToInt(invincibilityTimer).ToString();
    }
    public void ActivateInvincibility(float duration)
    {
        isInvincible = true;
        invincibilityDuration = duration;
        invincibilityTimer = duration;
    }
    void PlayDestroySound()
    {
        audioSource.PlayOneShot(DestroySound);
    }

    public void SetMaxHealth(int health)
    {
        if (health <= 0)
            health = 0;
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        if (health <= 0)
            health = 0;
        DisplayHealth = health;
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    public float GetHealth()
    {
        return slider.value;
    }

    public void IncreaseHealth(int amount)
    {
        float newHealth = GetHealth() + amount;

        // Ensure the new health value does not exceed the maximum
        newHealth = Mathf.Clamp(newHealth, 0f, slider.maxValue);

        // Set the new health value
        SetHealth(newHealth);

    }
}
