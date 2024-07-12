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

    //Oyunu Ba�latmak i�in �zelle�mi� ve ay�rmak istedim. [UI Controller'da olsa daha iyi olurdu ancak gerek yok :) ]
    public void UI_StartGameButton()
    {
        //Basic olarak ayn�
        // SceneManager.LoadScene(activeSceneIndex++);
        SceneManager.LoadScene(1); //1.Sahnemiz
    }

    //Bol�m sonu
    void UI_EndofTheSystem()
    {
        ++activeSceneIndex;
        SceneManager.LoadScene(activeSceneIndex);
    }
}
