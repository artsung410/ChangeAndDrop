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
    private int deletedBallCount;

    private int[] StarsCount = { 0, 0, 0, 0 };

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

    public int DeletedBallCount
    {
        get => deletedBallCount;
        set => deletedBallCount = value;
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
        SceneManager.LoadScene((int)Scene.Game);
        currentBallCount = 5;
        deletedBallCount = 0;
    }

    public void SetStars(int Count)
    {
        StarsCount[CurrentLevel - 1] = Count;
    }

    public int GetStarsCount(int level)
    {
        return StarsCount[level];
    }

    public void activeGameOver()
    {
        onGameOverEvent.Invoke();
    }
}
