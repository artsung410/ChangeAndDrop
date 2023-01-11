using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
    
    // ###############################################
    //             NAME : ARTSUNG                      
    //             MAIL : artsung410@gmail.com         
    // ###############################################

public class LevelButton : MonoBehaviour, IPointerDownHandler
{
    public enum Star
    {
        Emptied,
        Full
    }

    private int level;

    [SerializeField]
    private TextMeshProUGUI Tmp_Level;

    [SerializeField]
    private List<Image> Image_Rank;

    [SerializeField]
    private List<Sprite> Sprite_Stars;


    public void Init(int level)
    {
        this.level = level;
        Tmp_Level.text = level.ToString();
        InitRank();
    }

    public void SetRank(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Sprite_Stars[i] = Sprite_Stars[(int)Star.Full];
        }
    }

    public void InitRank()
    {
        int count = Image_Rank.Count;

        for (int i = 0; i < count; i++)
        {
            Image_Rank[i].sprite = Sprite_Stars[(int)Star.Emptied];
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.Instance.StageLoad(level);
    }
}
