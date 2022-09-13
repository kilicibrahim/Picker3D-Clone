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
        //(lvlN % 10) - 1
        switch (4)
        {
            case 9:
                POC.createParentObj(2, 14, 0, 0); // First one is how many object parents, second one is how many objects in the parents, Third one is which platform (for ex Platform"0") objects, The last one is line-up style
                POC.createParentObj(4, 8, 1, 1);
                POC.createParentObj(1, 120, 2, 2);
                break;
            case 8:
                POC.createParentObj(2, 14, 0, 0);
                POC.createParentObj(4, 8, 1, 1);
                POC.createParentObj(1, 120, 2, 2);
                break;
            case 7:
                POC.createParentObj(2, 14, 0, 0);
                POC.createParentObj(4, 8, 1, 1);
                POC.createParentObj(1, 120, 2, 2);
                break;
            case 6:
                POC.createParentObj(2, 14, 0, 0);
                POC.createParentObj(4, 8, 1, 1);
                POC.createParentObj(1, 120, 2, 2);
                break;
            case 5:
                POC.createParentObj(2, 14, 0, 0);
                POC.createParentObj(4, 8, 1, 1);
                POC.createParentObj(1, 120, 2, 2);
                break;
            case 4:
                Debug.Log("Lvl 5");
                POC.createParentObj(2, 14, 0, 0);
                POC.createParentObj(4, 9, 1, 4);
                POC.createParentObj(1, 120, 2, 2);
                break;
            case 3:
                Debug.Log("Lvl 4");
                POC.createParentObj(2, 14, 0, 0);
                POC.createParentObj(4, 8, 1, 1);
                POC.createParentObj(1, 40, 2, 3);
                break;
            case 2:
                Debug.Log("Lvl 3");
                POC.createParentObj(4, 5, 0, 1);
                POC.createParentObj(5, 6, 1, 1);
                POC.createParentObj(2, 24, 2, 2);
                break;
            case 1:
                Debug.Log("Lvl 2");
                POC.createParentObj(3, 10, 0, 1);
                POC.createParentObj(4, 8, 1, 1);
                POC.createParentObj(1, 120, 2, 2);
                break;
            default:
                Debug.Log("Lvl 1");
                POC.createParentObj(2, 14, 0, 0); 
                POC.createParentObj(4, 8, 1, 1);
                POC.createParentObj(1, 90, 2, 2);
                break;
        }
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
