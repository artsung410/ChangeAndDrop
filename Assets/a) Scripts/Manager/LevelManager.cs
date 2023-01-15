using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
    
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

    [SerializeField]
    private List<Image> Stars;

    [SerializeField]
    private Sprite StarSprites;

    [SerializeField]
    private TextMeshProUGUI Score;

    private int FinalStage = 4;

    private void OnEnable()
    {
        Init();
        EndTrigger.onGameClearEvent += ActivationInfoPanel;
        GameManager.Instance.onGameOverEvent += ActivationGameFailedPanel;
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

    int starCount = 0;
    public void ActivationInfoPanel()
    {
        float ratio = (float)GameManager.Instance.DeletedBallCount / GameManager.Instance.CurrentBallCount;

        if(ratio < 0.05f)
        {
            starCount = 3;
        }
        else if (ratio < 0.07f && ratio > 0.05f)
        {
            starCount = 2;
        }
        else
        {
            starCount = 1;
        }

        for (int i = 0; i < starCount; i++)
        {
            Stars[i].sprite = StarSprites;
        }

        Score.text = GameManager.Instance.CurrentBallCount.ToString();
        GameManager.Instance.SetStars(starCount);
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

    private void OnDisable()
    {
        EndTrigger.onGameClearEvent -= ActivationInfoPanel;
        GameManager.Instance.onGameOverEvent -= ActivationGameFailedPanel;
    }
}
