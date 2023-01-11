using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field_Start : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerPf;

    [SerializeField]
    private Transform PlayerSpawnPoint;

    public void SpawnCharacter()
    {
        Instantiate(PlayerPf, PlayerSpawnPoint.position, Quaternion.identity);
    }
}
