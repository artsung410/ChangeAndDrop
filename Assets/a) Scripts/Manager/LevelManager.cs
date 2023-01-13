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

    [SerializeField]
    private GameObject GameFailedPanel;

    private int FinalStage = 2;

    private void Awake()
    {
        EndTrigger.onGameClearEvent += ActivationInfoPanel;
        GameManager.Instance.onGameOverEvent += ActivationGameFailedPanel;

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

    public void LoadeScene_RetryStage()
    {
        GameManager.Instance.StageLoad(GameManager.Instance.CurrentLevel);
    }

    public void ActivationInfoPanel()
    {
        GameClearPanel.SetActive(true);
    }

    public void DeActivationInfoPanel()
    {
        GameClearPanel.SetActive(false);
    }

    public void ActivationGameFailedPanel()
    {
        GameFailedPanel.SetActive(true);
    }

    public void DeActivationGameFailedPanel()
    {
        GameFailedPanel.SetActive(false);
    }

    private void OnDestroy()
    {
        EndTrigger.onGameClearEvent -= ActivationInfoPanel;
        GameManager.Instance.onGameOverEvent -= ActivationGameFailedPanel;
    }
}
