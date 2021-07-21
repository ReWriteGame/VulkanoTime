using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SlotsIcon", order = 1)]
public class GameInstance : ScriptableObject
{
    static public GameInstance Instance { get;/* private*/ set; }

  
    void Start()
    {
        Instance = this;// инициализируем экземпл€ром класса на котором висит скрипт

     
    }
   
}
