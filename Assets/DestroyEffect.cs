using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    private float delay = 1f;

    private void Start()
    {
        Invoke("DestroyEffectMethod",delay);
    }

    void DestroyEffectMethod()
    {
        Destroy(gameObject);   
    }
}
