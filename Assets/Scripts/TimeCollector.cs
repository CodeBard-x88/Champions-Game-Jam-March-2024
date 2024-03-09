using UnityEngine;

public class TimeCollector : MonoBehaviour
{
    public float timeAmount = 10f; // Amount of time to increase when collected
    public AudioSource sound; // Sound to play when collected
    public ReverseTimerController timecontroller;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {


            timecontroller.setTime(5f);

            Debug.Log("TIME COLLECTED" + timecontroller.GetTimer());


            Destroy(gameObject);

            sound.Play();

        }
    }
}
