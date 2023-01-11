using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    
    // ###############################################
    //             NAME : ARTSUNG                      
    //             MAIL : artsung410@gmail.com         
    // ###############################################

public enum Scene
{
    Title,
    Stage,
    Game,
}
public class GameManager : Singleton<GameManager>
{
    public Scene CurrentScene;
    public int CurrentLevel;
    private int unlockCount;

    public int UnLockCount
    {
        get => unlockCount;
        set => unlockCount = value;
    }

    private void Start()
    {
        UnLockCount = 4;
        CurrentScene = Scene.Title;
    }

    public void StageLoad(int level)
    {
        CurrentLevel = level;
        CurrentScene = Scene.Game;
        Debug.Log($"현재 레벨은 {CurrentLevel} 입니다.");
        //SceneManager.LoadScene((int)Scene.Game);
    }
}
