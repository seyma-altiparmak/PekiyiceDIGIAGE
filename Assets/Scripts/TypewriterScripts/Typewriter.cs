using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TypewriterMessage
{
    private float timer = 0;
    private int charIndex = 0;
    private float timePerChar = 0.05f;

    [SerializeField]
    public string currentMsg = null;
    private string displayMsg = "";

    private Action onActionCallback = null;

    public TypewriterMessage(string msg, Action callback = null)
    {
        onActionCallback = callback;
        currentMsg = msg;
    }

    public string Callback()
    {
        if (onActionCallback != null)
        {
            onActionCallback();
        }
        return currentMsg;
    }

    public string GetFullMsg()
    {
        return currentMsg;
    }

    public string GetMsg()
    {
        return displayMsg;
    }

    public void Update()
    {
        if (string.IsNullOrEmpty(currentMsg)) return;

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer += timePerChar;
            charIndex++;

            displayMsg = currentMsg.Substring(0, charIndex);
            displayMsg += "<color=#00000000>" + currentMsg.Substring(charIndex) + "</color>";

            if (charIndex >= currentMsg.Length)
            {
                Callback();
                currentMsg = null;
            }
        }
    }

    public bool IsActive()
    {
        return currentMsg != null;
    }

    public string GetFullMsgAndCallback()
    {
        Callback();
        return currentMsg;
    }
}

public class Typewriter : MonoBehaviour
{
    public Text TextComponent;

    private static Typewriter instance;
    private List<TypewriterMessage> messages = new List<TypewriterMessage>();

    private TypewriterMessage currentMsg = null;
    private int msgIndex = 0;

    public static void Add(string msg, Action callback = null)
    {
        if (instance == null)
        {
            Debug.LogError("Typewriter instance is not set. Ensure there is a Typewriter component in the scene.");
            return;
        }
        TypewriterMessage typeMsg = new TypewriterMessage(msg, callback);
        instance.messages.Add(typeMsg);
    }

    public static void Activate()
    {
        if (instance.messages.Count > 0)
        {
            instance.currentMsg = instance.messages[0];
        }
    }

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (messages.Count > 0 && currentMsg != null)
        {
            currentMsg.Update();
            TextComponent.text = currentMsg.GetMsg();

            if (!currentMsg.IsActive())
            {
                WriteNextMessageInQueue();
            }
        }
    }

    public void WriteNextMessageInQueue()
    {
        msgIndex++;

        if (msgIndex >= messages.Count)
        {
            currentMsg = null;
            TextComponent.text = "";
            return;
        }

        currentMsg = messages[msgIndex];
    }
}
