using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Saliste.");
        Application.Quit();
    }

}
