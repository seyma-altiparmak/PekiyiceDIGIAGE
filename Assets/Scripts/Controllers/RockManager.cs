using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockManager : MonoBehaviour
{
    private UIControllerManager uiControllerManager;
    private GameObject rock;
    private int rockIndex;
    private int totalRockIndex;

    private void Start()
    {
         uiControllerManager = GetComponent<UIControllerManager>();
    }
    public void RandomRockIndex()
    {
        rockIndex = Random.RandomRange(0, 20);
        print("cekilen rock index : " + rockIndex);
        while(rockIndex < 0)
        {
            totalRockIndex++;
            rockIndex = rockIndex - 1;
        }

        uiControllerManager.rockIndexCounter.text = "X" + (totalRockIndex).ToString();
    }
}
