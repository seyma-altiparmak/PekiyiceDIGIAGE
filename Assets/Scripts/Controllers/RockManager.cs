using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockManager : MonoBehaviour
{
    private UIControllerManager uiControllerManager;
    private GameObject rock;
    private int rockIndex;
    public int totalRockIndex;

    private void Start()
    {
         uiControllerManager = GetComponent<UIControllerManager>();
    }
    public void RandomRockIndex()
    {
        rockIndex = Random.RandomRange(0, 20);
        print("cekilen rock index : " + rockIndex);
        while(rockIndex > 0)
        {
            print("rock counterým" + rockIndex);
            totalRockIndex++;
            rockIndex = rockIndex - 1;
        }
    }
}
