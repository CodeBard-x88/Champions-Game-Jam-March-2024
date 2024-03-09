using UnityEngine;
using UnityEngine.SceneManagement;

public class Endline : MonoBehaviour
{
    public Canvas canvas;

    private void Start()
    {
        canvas.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("HIT FUTURE");

            canvas.enabled = true;
            Time.timeScale = 0;
           // SceneManager.LoadScene("Future");

        }
    }
} 
