using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeToRules()
    {
        SceneManager.LoadScene(1);
    }
    
    public void ChangeToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ChangeToGame()
    {
        SceneManager.LoadScene(2);
    }
}
