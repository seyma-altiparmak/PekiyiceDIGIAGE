using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<IAMLight>(out IAMLight light))
        {
            //çalýþýyor.
            
        }
    }
}
