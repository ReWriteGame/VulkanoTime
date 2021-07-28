using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AbmobController", menuName = "ScriptableObjects/AdmobController", order = 1)]

public class AdController : ScriptableObject
{
    [SerializeField] private Admob admob;


    void ds()
    {
        if (Random.Range(0, 5) == 0)
            MonoBehaviour.print(1);
    }
}
