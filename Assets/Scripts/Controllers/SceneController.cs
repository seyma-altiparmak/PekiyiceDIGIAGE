using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    int activeSceneIndex;
    void Start()
    {
        activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    //Oyunu Baþlatmak için özelleþmiþ ve ayýrmak istedim. [UI Controller'da olsa daha iyi olurdu ancak gerek yok :) ]
    public void UI_StartGameButton()
    {
        //Basic olarak ayný
        // SceneManager.LoadScene(activeSceneIndex++);
        SceneManager.LoadScene(1); //1.Sahnemiz
    }

    //Bolüm sonu
    void UI_EndofTheSystem()
    {
        ++activeSceneIndex;
        SceneManager.LoadScene(activeSceneIndex);
    }
}
