using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public static bool gameIsPaused;
    public GameObject Canvas;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
            ActivateCanvas();
        }
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    UnpauseGame();
        //    DeactivateCanvas();
        //}
    }

    //public void PauseGame ()
    //{
    //    if(gameIsPaused)
    //    {
    //        Time.timeScale = 0f;
    //    }
    //    else 
    //    {
    //        Time.timeScale = 1;
    //    }
    //}

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
    }

    public void ActivateCanvas()
    {
        Canvas.SetActive(true);
    }

    public void DeactivateCanvas()
    {
        Canvas.SetActive(false);
    }
}