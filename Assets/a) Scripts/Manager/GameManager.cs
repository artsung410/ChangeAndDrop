using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
    
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
    public event Action onGameOverEvent = delegate { };
    public Scene CurrentScene;
    public int CurrentLevel;
    private int unlockCount;
    private int currentBallCount;

    public int UnLockCount
    {
        get => unlockCount;
        set => unlockCount = value;
    }

    public int CurrentBallCount
    {
        get => currentBallCount;

        set
        {
            currentBallCount = value;

            if (currentBallCount <= 0)
            {
                activeGameOver();
            }
        }
    }

    private void Start()
    {
        UnLockCount = 4;
        currentBallCount = 5;
        CurrentScene = Scene.Title;
    }

    public void StageLoad(int level)
    {
        CurrentLevel = level;
        CurrentScene = Scene.Game;
        Debug.Log($"현재 레벨은 {CurrentLevel} 입니다.");
        SceneManager.LoadScene((int)Scene.Game);
        currentBallCount = 5;
    }

    public void activeGameOver()
    {
        onGameOverEvent.Invoke();
    }
}
