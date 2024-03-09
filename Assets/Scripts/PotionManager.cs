using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PotionManager : MonoBehaviour
{
    public Text potionCountText; // Reference to the UI text element displaying potion count
    private int potionCount = 0; // Variable to store the count of potions

    void Start()
    {
        UpdatePotionCountUI();
    }

    public void IncrementPotionCount()
    {
        potionCount++;

        UpdatePotionCountUI();

        if (potionCount >= 10)
        {
            SceneManager.LoadScene("Future");
        }
    }

    private void UpdatePotionCountUI()
    {
        if (potionCountText != null)
        {
            potionCountText.text = potionCount.ToString();
        }
    }
}
