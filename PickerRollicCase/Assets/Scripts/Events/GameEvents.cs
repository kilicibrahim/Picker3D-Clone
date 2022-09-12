using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    void Awake()
    {
        current = this;
    }

    public event Action<int> onLvlStart;
    public void LvlStart(int lvlN) // lvlN = Level Number
    {
        if (onLvlStart != null)
        {
            onLvlStart(lvlN);
        }
    }

    public event Action<int> onBasketEnter; 
    public void BasketEnter(int bN) //bN = Basket Number
    {
        if(onBasketEnter != null)
        {
            onBasketEnter(bN);
        }
    }

    public event Action<int> onBasketExit;
    public void BasketExit(int bN) //bN = Basket Number
    {
        if (onBasketExit != null)
        {
            onBasketExit(bN);
        }
    }

    public event Action<int> onFailedAttemp;
    public void FailedAttemp(int lvlN) // lvlN = Level Number
    {
        if (onFailedAttemp != null)
        {
            onFailedAttemp(lvlN);
        }
    }

    public event Action<int> onLvlFinish;
    public void LvlFinish(int lvlN) // lvlN = Level Number
    {
        if (onLvlFinish != null)
        {
            onLvlFinish(lvlN);
        }
    }


}
