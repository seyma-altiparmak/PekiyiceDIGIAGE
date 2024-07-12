using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIControllerManager : MonoBehaviour
{
    private TextMeshProUGUI ruinTimeCounter;
    [HideInInspector] public TextMeshProUGUI rockIndexCounter;
    [SerializeField] private float updateInterval = 0.1f;
    [SerializeField] private float countdownStep = 0.1f;
    [HideInInspector] public float totalTimer = 20f;
    [HideInInspector] public bool isItRuin = false;

    private void Start()
    {
        ruinTimeCounter = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
        rockIndexCounter = GameObject.Find("RockCounter").GetComponent <TextMeshProUGUI>();
        StartCoroutine(CountdownTimer());
    }

    private IEnumerator CountdownTimer()
    {
        while (true)
        {
            while (totalTimer > 0 && !isItRuin)
            {
                totalTimer -= countdownStep;
                totalTimer = Mathf.Max(totalTimer, 0);
                UpdateTimerText();
                yield return new WaitForSeconds(updateInterval);
            }

            if (totalTimer == 0)
            {
                ruinTimeCounter.text = "DIVE!";
                isItRuin = true;
                yield return new WaitForSeconds(5.0f);
                UpdateTimerText();
            }
        }
    }

    private void UpdateTimerText()
    {
        ruinTimeCounter.text = $"My total timer: {Mathf.CeilToInt(totalTimer)}";
    }
}
