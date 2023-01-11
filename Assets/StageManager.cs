using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
    
    // ###############################################
    //             NAME : ARTSUNG                      
    //             MAIL : artsung410@gmail.com         
    // ###############################################

public class StageManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Panel_Level;

    [SerializeField]
    private GameObject LevelButton;

    [SerializeField]
    private GameObject LockButton;

    [SerializeField]
    private int SpawnCount;

    private int unlockCount;

    private void Awake()
    {
        unlockCount = GameManager.Instance.UnLockCount;
        SpawnLevelButton();
    }

    private void SpawnLevelButton()
    {
        for (int i = 0; i < SpawnCount; i++)
        {
            if (i < unlockCount)
            {
                GameObject newObj = Instantiate(LevelButton, Panel_Level.transform);
                LevelButton levelButton = newObj.GetComponent<LevelButton>();

                levelButton.Init(i + 1);
            }
            else
            {
                Instantiate(LockButton, Panel_Level.transform);
            }
        }
    }

    public void LoadScene_Title()
    {
        SceneManager.LoadScene((int)Scene.Title);
        GameManager.Instance.CurrentScene = Scene.Title;
    }
}
