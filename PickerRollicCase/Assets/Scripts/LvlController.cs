using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlController : MonoBehaviour //we have 3 platforms and 3 baskets to pass a lvl, we will create pushible object pairs for each one of them
{
    PushibleObjectController POC;
    void Start()
    {
        POC = this.gameObject.GetComponent<PushibleObjectController>();
        GameEvents.current.onLvlStart += CreateLvl;
        GameEvents.current.onLvlFinish += FinishedLevel;
    }

    void CreateLvl(int lvlN) // there are 3 platforms and baskets in each lvl we will call first 10 lvls as we wanted, after that there will be random lvls
    {
        switch ((lvlN % 10)-1 ) // Add more colors
        {
            case 9:
                Lvl1();
                break;
            case 8:
                Lvl1();
                break;
            case 7:
                Lvl1();
                break;
            case 6:
                Lvl1();
                break;
            case 5:
                Lvl1();
                break;
            case 4:
                Lvl1();
                break;
            case 3:
                Lvl1();
                break;
            case 2:
                Lvl1();
                break;
            case 1:
                Lvl1();
                Debug.Log("SecondLVL");
                break;
            default:
                Lvl1();
                break;
        }
    }

    private void Lvl1()
    {
        POC.createParentObj(2, 14, 0); // First one is how many object parents, second one is how many objects in the parents, Third one is which platform (for ex Platform"0") objects
        POC.createParentObj(2, 14, 1);
        POC.createParentObj(2, 14, 2);

    }

    private void FinishedLevel(int lvlN)
    {
        TapToStart.lvlN += 1;
    }

    private void OnDestroy()
    {
        GameEvents.current.onLvlStart -= CreateLvl;
        GameEvents.current.onLvlFinish -= FinishedLevel;
    }
}
