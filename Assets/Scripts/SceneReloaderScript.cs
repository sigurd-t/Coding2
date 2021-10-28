using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// IMPORTANT LINE
using UnityEngine.SceneManagement;

public class SceneReloaderScript : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Polygons");
        }
    }
}
