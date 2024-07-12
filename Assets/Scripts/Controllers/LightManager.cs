using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    private Animator animatorController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IAMLight>(out IAMLight light))
        {
            animatorController = light.GetComponent<Animator>();
            if (animatorController == null)
            {
                print("Animator component not found.");
            }
            else
            {
                animatorController.SetTrigger("TouchLight");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IAMLight light))
        {
            animatorController.SetTrigger("CatchLight");
        }
    }
}
