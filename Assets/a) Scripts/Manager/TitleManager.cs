using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    
    // ###############################################
    //             NAME : ARTSUNG                      
    //             MAIL : artsung410@gmail.com         
    // ###############################################

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Tool;

    public void LoadScene_Stage()
    {
        SceneManager.LoadScene((int)Scene.Stage);
        GameManager.Instance.CurrentScene = Scene.Stage;
    }

    public void ActivationTool()
    {
        Tool.SetActive(true);
    }

    public void DeActivationTool()
    {
        Tool.SetActive(false);
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
