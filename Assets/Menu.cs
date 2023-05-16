using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{   

    public static bool isLevel1done = false;
    [SerializeField]Button lvl2;

    [SerializeField] bool isSelector;

    void Start()
    {
        if(isSelector)
        {
            if(isLevel1done == false)
                {
            lvl2.interactable = false;
                }
        }
        
    }
    public void switchScreen(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
