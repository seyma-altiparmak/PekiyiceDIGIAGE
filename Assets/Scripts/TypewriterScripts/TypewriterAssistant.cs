
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypewriterAssistant : MonoBehaviour
{
    private void Start()
    {
        Typewriter.Add("first message");
        Typewriter.Add("second message");
        Typewriter.Add("third message");

        Typewriter.Activate();
    }
}
