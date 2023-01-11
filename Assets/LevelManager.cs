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

    private void Awake()
    {
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

    public void Spawn()
    {
        GameObject newObj = GameObject.FindGameObjectWithTag("Start");
        newObj.GetComponent<Field_Start>().SpawnCharacter();
    }
}
