using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    
    // ###############################################
    //             NAME : ARTSUNG                      
    //             MAIL : artsung410@gmail.com         
    // ###############################################

public class LevelManager : MonoBehaviour
{
    public List<GameObject> Level;

    [SerializeField]
    private GameObject GameClearPanel;

    private int FinalStage = 2;

    private void Awake()
    {
        EndTrigger.onGameClearEvent += ActivationGameClearPanel;
        Init();
    }

    public void Init()
    {
        Instantiate(Level[GameManager.Instance.CurrentLevel - 1], transform.position, transform.rotation);
    }

    public void LoadScene_Stage()
    {
        SceneManager.LoadScene((int)Scene.Stage);
        GameManager.Instance.CurrentScene = Scene.Stage;
    }

    public void LoadScene_NextStage()
    {
        if (GameManager.Instance.CurrentLevel == FinalStage)
        {
            Debug.Log("마지막 스테이지 입니다.");
            return;
        }

        GameManager.Instance.StageLoad(GameManager.Instance.CurrentLevel + 1);
    }

    public void ActivationGameClearPanel()
    {
        GameClearPanel.SetActive(true);
    }

    public void DeActivationGameClearPanel()
    {
        GameClearPanel.SetActive(false);
    }

    private void OnDestroy()
    {
        EndTrigger.onGameClearEvent -= ActivationGameClearPanel;
    }
}
