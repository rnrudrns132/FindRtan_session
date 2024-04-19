using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    int a = 5;
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
