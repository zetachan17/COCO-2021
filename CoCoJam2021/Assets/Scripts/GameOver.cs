using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RestartButtion()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitButton()
    {
        SceneManager.LoadScene(0);
    }
}
